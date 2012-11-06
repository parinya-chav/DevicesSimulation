using System.Data.Entity;
using DeviceSimulation.Domain;

namespace DeviceSimulation.Infrastructure
{
    public class DSContext : DbContext
    {
        public IDbSet<SimDoc> SimDocs { get; set; }
        public IDbSet<SimDevice> SimDevices { get; set; }        
    }
}
