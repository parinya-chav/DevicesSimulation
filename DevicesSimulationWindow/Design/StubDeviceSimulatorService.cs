using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevicesSimulationWindow.Model;
using DevicesSimulationWindow.ViewModel;
using System.Collections.ObjectModel;

using DevicesSimulation.Services;
using DeviceSimulation.Domain;

namespace DevicesSimulationWindow.Design
{
    public class StubDeviceSimulatorService : IDeviceSimulatorService
    {
        public StubDeviceSimulatorService()
        {
            
        }
        
        private List<SimDeviceViewModel> PreSimDevices()
        {
            var simDeviceViewModel = new List<SimDeviceViewModel>();

            string[] descs = { "James", "John", "Danny", "Michelle", "Tina", "Rachel", "Todd", "Elaine", "Tonya", "Derek", "Mike" };
            string[] imei = { "SIM001A", "SIM0002", "SIM0003", "SIM000X", "SIM00TT", "SIM00YU", "SIM0088", "SIM00PP", "SIM0078", "SIM00WW", "SIM00QW" };

            Random r2 = new Random();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int index = r.Next(0, 11);
                SimDeviceViewModel p = new SimDeviceViewModel
                {
                    Imei = imei[index],
                    Description = descs[index],
                    SendTotal = r2.Next(10, 90),
                };
                simDeviceViewModel.Add(p);
            }           

            return simDeviceViewModel;
        }

        public ObservableCollection<SimDeviceViewModel> LoadAllSimDeviceViewModel()
        {
            var preSimDevices = PreSimDevices();
            ObservableCollection<SimDeviceViewModel> simDeviceList = new ObservableCollection<SimDeviceViewModel>();
            preSimDevices.ForEach(i =>
            {
                simDeviceList.Add(new SimDeviceViewModel
                {
                    Imei = i.Imei,
                    IsCheckChoose = i.IsCheckChoose,

                    Description = i.Description,
                    SendComplete = i.SendComplete,
                    SendTotal = i.SendTotal,
                    SendTime = i.SendTime,
                    Status = i.Status,
                    IsFinish = i.IsFinish
                });
            });
            return simDeviceList;
        }



        public IList<SimDeviceViewModel> AddDevices(int qtyDevices, int qtyXml, int sendTime)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<StatusWorkingModel> GetAllStatusWorking()
        {
            throw new NotImplementedException();
        }

        public string SendPacket()
        {
            throw new NotImplementedException();
        }

        public bool SaveSimDevices(ObservableCollection<SimDeviceViewModel> simDeviceViewModel, HeaderDevicesSimulatorViewModel headerDevicesSimulatorViewModel)
        {
            throw new NotImplementedException();
        }

        public IList<DeviceSimulatorModel> GetAllDeviceSimulator()
        {
            throw new NotImplementedException();
        }

        public IList<SimDeviceViewModel> getSimDevicesByDeviceSimulatorId(int id)
        {
            throw new NotImplementedException();
        }


        DeviceSimulatorModel IDeviceSimulatorService.getSimDevicesByDeviceSimulatorId(int id)
        {
            throw new NotImplementedException();
        }


        public bool SaveCreateSimDevices(ObservableCollection<SimDeviceViewModel> simDeviceViewModel, HeaderDevicesSimulatorViewModel headerDevicesSimulatorViewModel)
        {
            throw new NotImplementedException();
        }

        public bool SaveChangeSimDevices(ObservableCollection<SimDeviceViewModel> simDeviceViewModel, HeaderDevicesSimulatorViewModel headerDevicesSimulatorViewModel)
        {
            throw new NotImplementedException();
        }


        int IDeviceSimulatorService.SaveSimDevices(ObservableCollection<SimDeviceViewModel> simDeviceViewModel, HeaderDevicesSimulatorViewModel headerDevicesSimulatorViewModel)
        {
            throw new NotImplementedException();
        }

        int IDeviceSimulatorService.SaveCreateSimDevices(ObservableCollection<SimDeviceViewModel> simDeviceViewModel, HeaderDevicesSimulatorViewModel headerDevicesSimulatorViewModel)
        {
            throw new NotImplementedException();
        }

        int IDeviceSimulatorService.SaveChangeSimDevices(ObservableCollection<SimDeviceViewModel> simDeviceViewModel, HeaderDevicesSimulatorViewModel headerDevicesSimulatorViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
