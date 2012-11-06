using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevicesSimulationApp.Models
{
    public class DeviceSimulatorModel
    {
        public DeviceSimulatorModel() 
        { }

        private IList<SimDeviceModel> simDeviceModel;
        public IList<SimDeviceModel> SimDeviceModel
        {
            get { return simDeviceModel; }
            set { simDeviceModel = value; }
        }
    }
}
