using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevicesSimulationWindow.Model
{
    public class AddSimDevicesModel
    {
        private int qty;
        private int sendTime;
        private int qtyXml;

        public int Qty
        {
            get { return qty; }
            set
            {
                qty = value;
            }
        }
        public int SendTime
        {
            get { return sendTime; }
            set
            {
                sendTime = value;
            }
        }
        public int QtyXml
        {
            get { return qtyXml; }
            set
            {
                qtyXml = value;
            }
        }
    }
}
