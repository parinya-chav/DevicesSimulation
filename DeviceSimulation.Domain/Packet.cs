using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviceSimulation.Domain
{
    public class Packet : Domain
    {
        public virtual string MessageType { get; set; }
        public virtual byte[] Row { get; set; }

        public virtual SimDevice SimDevice { get; set; }
    }
}
