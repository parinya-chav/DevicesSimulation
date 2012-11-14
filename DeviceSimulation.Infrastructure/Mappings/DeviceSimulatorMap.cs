using FluentNHibernate.Mapping;
using DeviceSimulation.Domain;

namespace DeviceSimulation.Infrastructure.Mappings
{
    public class DeviceSimulatorMap : ClassMap<DeviceSimulator>
    {
        public DeviceSimulatorMap()
        {
            Table("DeviceSimulators");
            Id(x => x.Id);
            Map(x => x.Status);
            Map(x => x.Description);
            HasMany(x => x.SimDevices)
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}
