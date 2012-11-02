using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviceSimulation.Domain
{
    public class SimDevice
    {
        public string Imei { get; set; }
        public string Description { get; set; }
        public int SendTotal { get; set; }
    }
}
