using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviceSimulation.Domain
{
    public interface IDeviceSimulator
    {
        string Name { get; set; }
        SimDoc SimDoc { get; set; }
        IList<SimDevice> SimDevices { get; set; }
        void Start();
    }
}
