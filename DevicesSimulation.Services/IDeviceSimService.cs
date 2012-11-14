using System.Collections.Generic;

using DeviceSimulation.Domain;

namespace DevicesSimulation.Services
{
    public interface IDeviceSimService
    {       
        IList<DeviceSimulator> GetAllDeviceSimulator();
        DeviceSimulator GetByIdDeviceSimulator(int id);
        DeviceSimulator GetByIdDeviceSimulatorIncludeChild(int id);
        SimDevice GetByIdSimDevice(int id);
        string SendPacket(SimDevice simDevice);
        IList<Packet> GetPacketsByIdSimDevice(int id);
    }
}
