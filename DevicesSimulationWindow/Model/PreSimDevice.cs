using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using GalaSoft.MvvmLight;

namespace DevicesSimulationWindow.Model
{
    public class PreSimDevice
    {
        public string Imei { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }
        public bool IsFinish { get; set; }
        public int SendTime { get; set; }
        public bool IsCheckChoose { get; set; }
        public int SendComplete { get; set; }
        public int SendTotal { get; set; }
    }
}
