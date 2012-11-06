using System.Data.Entity;
using DeviceSimulation.Domain;

namespace DevicesSimulationApp.Test.Infra
{
    public class DSContext : DbContext
    {
        public IDbSet<SimDevice> SimDevices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SimDeviceConfiguration());
        }
    }
}
