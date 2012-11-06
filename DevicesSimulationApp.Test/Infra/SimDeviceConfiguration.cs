using System.Data.Entity.ModelConfiguration;
using DeviceSimulation.Domain;

namespace DevicesSimulationApp.Test.Infra
{
    public class SimDeviceConfiguration : EntityTypeConfiguration<SimDevice>
    {
        public SimDeviceConfiguration()
        {
            this.Property(h => h.Imei).HasColumnType("varchar").HasMaxLength(20);
            this.Property(h => h.Description).HasColumnType("varchar").HasMaxLength(50);
            this.Property(h => h.SendTotal);
        }
    }
}
