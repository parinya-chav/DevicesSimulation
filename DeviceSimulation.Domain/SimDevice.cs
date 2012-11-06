using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviceSimulation.Domain
{
    public class SimDevice
    {
        public virtual SimDoc SimDoc { get; set; }

        public virtual Int64 Id { get; set; }
        public virtual string Imei { get; set; }
        public virtual string Description { get; set; }
        public byte Status { get; set; }
        public bool IsCheckChoose { get; set; }
        public bool IsFinish { get; set; }
        public int SendTime { get; set; }
        public int SendComplete { get; set; }
        public virtual int SendTotal { get; set; }
    }
}
