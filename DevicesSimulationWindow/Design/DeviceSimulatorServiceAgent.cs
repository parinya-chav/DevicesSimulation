using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using DevicesSimulationWindow.Model;
using DevicesSimulationWindow.ViewModel;
using DeviceSimulation.Domain;
using DevicesSimulation.Services;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using DeviceSimulation.Infrastructure.Mappings;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;

namespace DevicesSimulationWindow.Design
{
    public class DeviceSimulatorServiceAgent : IDeviceSimulatorService
    {
        IDeviceSimService _deviceSimService;

        ISession _session;
        public DeviceSimulatorServiceAgent()
        {
             ISessionFactory sessionFactory = CreateSessionFactory();
             _session = sessionFactory.OpenSession();

             _deviceSimService = new DeviceSimService(_session);
             
        }

        static string DBFile = "firstProgram.db";
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                .UsingFile(DBFile))
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<DeviceSimulatorMap>())
                    .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }
        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            
            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
                .Create(false, !File.Exists(DBFile));
        }
        public IList<SimDeviceViewModel> AddDevices(int qtyDevices, int qtyXml, int sendTime)
        {
            IList<SimDeviceViewModel> retSimDevices = new List<SimDeviceViewModel>();
            Random r = new Random();
            for (int i = 0; i < qtyDevices; i++)
            {
                var simDevice = new SimDeviceViewModel
                {
                    Imei = "SIM" + Convert.ToString(r.Next(0, 1000)).PadLeft(4, '0'),
                    Description = "Test",
                    SendTime = sendTime,
                    SendTotal = qtyXml,
                    Status = 0,
                    SendComplete = 0
                };

                retSimDevices.Add(simDevice);
            }
            return retSimDevices;
        }

        public ObservableCollection<StatusWorkingModel> GetAllStatusWorking()
        {
            ObservableCollection<StatusWorkingModel> statusWorking = new ObservableCollection<StatusWorkingModel>();
            statusWorking.Add(new StatusWorkingModel { StatusID = 0, Description = "Inactive" });
            statusWorking.Add(new StatusWorkingModel { StatusID = 1, Description = "Active" });
            statusWorking.Add(new StatusWorkingModel { StatusID = 2, Description = "Pause" });
            statusWorking.Add(new StatusWorkingModel { StatusID = 3, Description = "Finished" });

            return statusWorking;
        }

        DeviceSimulator _header = null;

        public string SendPacket(SimDeviceViewModel simDeviceViewModel)
        {
            string ret = "";
            var simDevice = _header.GetByChildId(simDeviceViewModel.Id);

            simDevice.SendComplete = simDeviceViewModel.SendComplete;
            simDevice.Status = simDeviceViewModel.Status;
            simDevice.SendTime = simDeviceViewModel.SendTime;

            ret = _deviceSimService.SendPacket(simDevice);

            lock (_session)
            {
                _session.Persist(simDevice);
            }

            return ret;
        }

        public int SaveSimDevices(ObservableCollection<SimDeviceViewModel> simDeviceViewModel, HeaderDevicesSimulatorViewModel headerDevicesSimulatorViewModel)
        {
            int result = 0;
            try
            {
                if (headerDevicesSimulatorViewModel.ID == 0)
                {
                    return SaveCreateSimDevices(simDeviceViewModel, headerDevicesSimulatorViewModel);
                }
                else
                {
                    return SaveChangeSimDevices(simDeviceViewModel, headerDevicesSimulatorViewModel);
                }                
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result;
        }


        public IList<DeviceSimulatorModel> GetAllDeviceSimulator()
        {
            var deviceSimulatorModels = new List<DeviceSimulatorModel>();
            var deviceSims = _deviceSimService.GetAllDeviceSimulator();

            foreach (var item in deviceSims)
            {
                deviceSimulatorModels.Add(new DeviceSimulatorModel
                {
                    Id = item.Id,
                    Description = item.Description
                });
                
            }
            return deviceSimulatorModels;
        }


        public DeviceSimulatorModel getSimDevicesByDeviceSimulatorId(int id)
        {
            var deviceSimulatorModel = new DeviceSimulatorModel();
            _header = _deviceSimService.GetByIdDeviceSimulatorIncludeChild(id);

            if (_header != null)
            {
                deviceSimulatorModel.Id = _header.Id;
                deviceSimulatorModel.Description = _header.Description;
                deviceSimulatorModel.Status = _header.Status;

                _header.SimDevices.ToList().ForEach(item =>
                {
                    deviceSimulatorModel.SimDeviceViewModel.Add(new SimDeviceViewModel
                    {
                        Id = item.Id,
                        Imei = item.Imei,
                        Description = item.Description,
                        SendTime = item.SendTime,
                        SendTotal = item.SendTotal,
                        Status = item.Status,
                        SendComplete = item.SendComplete,
                    });
                });

            }
            return deviceSimulatorModel;
        }

        public ObservableCollection<SimDeviceViewModel> LoadAllSimDeviceViewModel()
        {
            throw new NotImplementedException();
        }


        public int SaveCreateSimDevices(ObservableCollection<SimDeviceViewModel> simDeviceViewModel, HeaderDevicesSimulatorViewModel headerDevicesSimulatorViewModel)
        {
            int result = 0;
            try
            {
                DeviceSimulator deviceSimulator = new DeviceSimulator();
                deviceSimulator.Description = headerDevicesSimulatorViewModel.HeadName;
                deviceSimulator.Status = headerDevicesSimulatorViewModel.Status;

                foreach (var item in simDeviceViewModel)
                {
                    deviceSimulator.AddSimDevice(new SimDevice
                    {
                        Imei = item.Imei,
                        Description = item.Description,
                        Status = item.Status,
                        SendComplete = item.SendComplete,
                        SendTotal = item.SendTotal,
                        SendTime = item.SendTime
                    });
                }

                _session.SaveOrUpdate(deviceSimulator);
                result = deviceSimulator.Id;
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result;
        }

        public int SaveChangeSimDevices(ObservableCollection<SimDeviceViewModel> simDeviceViewModel, HeaderDevicesSimulatorViewModel headerDevicesSimulatorViewModel)
        {
            int result = 0;
            try
            {
                if (_header != null)
                {
                    if (headerDevicesSimulatorViewModel != null)
                    {
                        _header.Description = headerDevicesSimulatorViewModel.HeadName;
                        _header.Status = headerDevicesSimulatorViewModel.Status;
                                                
                        foreach (var itmChange in simDeviceViewModel)
                        {
                            if (itmChange.Id != 0)
                            {
                                var oldSim = _header.GetByChildId(itmChange.Id);
                                if (oldSim != null)
                                {
                                    oldSim.Description = itmChange.Description;

                                    oldSim.SendComplete = itmChange.SendComplete;
                                    oldSim.SendTime = itmChange.SendTime;
                                    oldSim.SendTotal = itmChange.SendTotal;
                                    oldSim.Status = itmChange.Status;
                                }

                                _session.Update(oldSim);
                                _session.Flush();
                            }

                        }
                        result = _header.Id;
                    }
                    else
                    {
                        result = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result;
        }
        public bool DeleteSimDevices(int deviceSimId, int simDeviceId)
        {
            var deviceSim = _deviceSimService.GetByIdDeviceSimulatorIncludeChild(deviceSimId);

            deviceSim.Remove(simDeviceId);
            _session.Flush();
            
            return true;
        }
             
    }
}
