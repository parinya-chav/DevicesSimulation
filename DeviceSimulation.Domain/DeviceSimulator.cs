using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviceSimulation.Domain
{
    public class DeviceSimulator : IDeviceSimulator
    {
        public string Name { get; set; }
        public IList<SimDevice> SimDevices { get; set; }



        public void Start()
        {
            
        }
    }
}
