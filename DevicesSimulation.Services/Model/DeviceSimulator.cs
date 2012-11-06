using DeviceSimulation.Domain;

namespace DevicesSimulation.Services.Model
{
    public class DeviceSimulator : IDeviceSimulator
    {

        public string Name
        {
            get;
            set;
        }

        public SimDoc SimDoc
        {
            get;
            set;
        }

        public System.Collections.Generic.IList<SimDevice> SimDevices
        {
            get;
            set;
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }
    }
}
