using FluentNHibernate.Mapping;
using DeviceSimulation.Domain;

namespace DeviceSimulation.Infrastructure.Mappings
{
    public class PacketMap : ClassMap<Packet>
    {
        public PacketMap()
        {
            Table("Packets");
            Id(x => x.Id);
            Map(x => x.Description);
            Map(x => x.MessageType);
            Map(x => x.Row);
            References(x => x.SimDevice);
        }
    }
}
