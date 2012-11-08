using System.Collections.Generic;

using DeviceSimulation.Domain;

namespace DevicesSimulation.Services
{
    public interface IDeviceSimService
    {
        int SaveSimDocs(DeviceSimulator deviceSimulator);
        IList<DeviceSimulator> GetAllDeviceSimulator();
        DeviceSimulator GetByIdDeviceSimulator(int id);
        DeviceSimulator GetByIdDeviceSimulatorIncludeChild(int id);
    }
}
