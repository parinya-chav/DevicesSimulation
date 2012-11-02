using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DeviceSimulation.Domain;

namespace DevicesSimulationWindow.Model
{
    public interface IPreDeviceSimulator : IDeviceSimulator
    {
        IList<PreSimDevice> PreSimDevices { get; set; }
    }
}
