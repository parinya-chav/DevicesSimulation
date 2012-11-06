using System.Collections.Generic;

using DeviceSimulation.Domain;

namespace DevicesSimulation.Services
{
    public interface IDeviceSimService
    {
        bool SaveSimDocs(IDeviceSimulator deviceSimulator);
    }
}
