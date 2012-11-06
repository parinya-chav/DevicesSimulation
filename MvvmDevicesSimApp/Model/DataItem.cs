using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MvvmDevicesSimApp.Model.View;

namespace MvvmDevicesSimApp.Model
{
    public class DataItem
    {
        public DataItem(string title)
        {
            Title = title;
        }

        public string Title
        {
            get;
            private set;
        }

        public DataItem()
        {
            _objctData = GetData().ToArray();            
        }
        //public DataItem()
        //{
        //    devicesSimulationView = new DevicesSimulationView();
        //    devicesSimulationView.SimDeviceView = new List<SimDeviceView>();
            
        //    int total = 10;
        //    int sendTime = 5;
        //    int sendTotal = 5;
        //    int qtyXml = 5;

        //    if (total > 0)
        //    {
        //        int i;
        //        for (i = 0; i < total; i++)
        //        {
        //            var deviceSim = new SimDeviceView();
        //            deviceSim.PackageView = new List<PackageView>();

        //            deviceSim.Imei = "SIM" + Convert.ToString(i + 1).PadLeft(4, '0');
        //            deviceSim.SendTime = sendTime;

        //            deviceSim.SendComplete = 0;
        //            deviceSim.SendTotal = sendTotal;

        //            int j;
        //            for (j = 0; j < qtyXml; j++)
        //            {
        //                var packageModel = new PackageView
        //                {
        //                    Sequence = j + 1,
        //                    Status = 0,
        //                    MessageType = ""
        //                };
        //                deviceSim.PackageView.Add(packageModel);
        //            }

        //            devicesSimulationView.SimDeviceView.Add(deviceSim);
        //        }
        //    }
        //}

        private object[] _objctData;
        public object[] ObjectData
        {
            get { return _objctData; }
        }

        public List<DevicesSimulationView> GetData()
        {
            string[] imeis = { "MCN-James", "MCN-John", "MCN-Danny", "MCN-Michelle", "MCN-Tina", "MCN-Rachel", "MCN-Todd", "MCN-Elaine", "MCN-Tonya", "MCN-Derek", "MCN-Mike" };
            string[] descs = { "Doe", "Thomas", "Smith", "Wahlin", "Taft", "Adams", "Schiller", "Carpenter", "Peterson", "Wilson", "Warner" };
            List<DevicesSimulationView> devices = new List<DevicesSimulationView>();

            Random r2 = new Random();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int index = r.Next(0, 11);
                DevicesSimulationView p = new DevicesSimulationView
                {
                    Imei = imeis[index],
                    Description = descs[index],
                    SendTotal = r2.Next(10, 90)
                };
                devices.Add(p);
            }
            return devices;
        }
    }
}
