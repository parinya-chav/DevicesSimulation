using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviceSimulation.Domain
{
    public class SimDevice : Domain
    {
        public virtual string Imei { get; set; }
        public virtual byte Status { get; set; }
        public virtual bool IsCheckChoose { get; set; }
        public virtual bool IsFinish { get; set; }
        public virtual int SendTime { get; set; }
        public virtual int SendComplete { get; set; }
        public virtual int SendTotal { get; set; }

        public virtual DeviceSimulator DeviceSimulator { get; set; }

        public virtual IList<Packet> Packet { get; set; }

        public SimDevice()
        {
            Packet = new List<Packet>();
        }

        public virtual void AddPacket(Packet packet)
        {
            packet.SimDevice = this;
            Packet.Add(packet);
        }
    }
}
