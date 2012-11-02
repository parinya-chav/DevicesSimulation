using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevicesSimulationWindow.Model;
using DevicesSimulationWindow.ViewModel;
using System.Collections.ObjectModel;

namespace DevicesSimulationWindow.Design
{
    public class StubDeviceSimulatorService : IDeviceSimulatorService
    {
        IPreDeviceSimulator _preDeviceSimulator;
        public StubDeviceSimulatorService()
        {
            _preDeviceSimulator = new StubDeviceSimulator();
        }

        public ObservableCollection<SimDeviceViewModel> LoadAllSimDeviceViewModel()
        {
            var preSimDevices = _preDeviceSimulator.PreSimDevices.ToList();
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
                    IsCheckChoose = false,
                    IsFinish = false,
                    SendComplete = 0
                };

                retSimDevices.Add(simDevice);
            }
            return retSimDevices;
        }


        public ObservableCollection<StatusWorkingModel> GetAllStatusWorking()
        {
            ObservableCollection<StatusWorkingModel> statusWorking = new ObservableCollection<StatusWorkingModel>();
            statusWorking.Add(new StatusWorkingModel { StatusID = 0, Description="Inactive" });
            statusWorking.Add(new StatusWorkingModel { StatusID = 1, Description = "Active" });

            return statusWorking;
        }


        public string SendPacket()
        {
            return "Send...";
        }
    }
}
