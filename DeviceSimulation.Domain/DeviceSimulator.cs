using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviceSimulation.Domain
{
    public class DeviceSimulator : Domain
    {        
        public virtual IList<SimDevice> SimDevices { get; protected set; }

        public DeviceSimulator()
        {
            SimDevices = new List<SimDevice>();
        }

        public virtual void AddSimDevice(SimDevice simDevice)
        {
            simDevice.DeviceSimulator = this;
            SimDevices.Add(simDevice);
        }

        public virtual void Remove(int simDeviceId)
        {
            var remove = SimDevices.Where(s => s.Id == simDeviceId).FirstOrDefault();
            if (remove != null)
            {
                SimDevices.Remove(remove);
            }
        }

        public virtual SimDevice GetByChildId(int simDeviceId)
        {
            return SimDevices.Where(s => s.Id == simDeviceId).FirstOrDefault();
        }


    }
}
