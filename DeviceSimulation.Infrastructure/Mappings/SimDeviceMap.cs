using FluentNHibernate.Mapping;
using DeviceSimulation.Domain;

namespace DeviceSimulation.Infrastructure.Mappings
{
    public class SimDeviceMap : ClassMap<SimDevice>
    {
        public SimDeviceMap()
        {
            Table("SimDevices");
            Id(x => x.Id);
            Map(x => x.Imei);
            Map(x => x.Description);
            Map(x => x.IsCheckChoose);
            Map(x => x.IsFinish);
            Map(x => x.SendComplete);
            Map(x => x.SendTime);
            Map(x => x.SendTotal);
            Map(x => x.Status);

            References(x => x.DeviceSimulator);
            HasMany(x => x.Packet)
                .Cascade.All()
                .Inverse();

        }
    }
}
