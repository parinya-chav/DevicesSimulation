using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DevicesSimulationApp.Models
{
    public class AddDevicesSimModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public AddDevicesSimModel()
        {                       
        }

        private int qty;
        public int Qty
        {
            get { return qty; }
            set { qty = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Qty"));
            }
        }

        private int sendTime;
        public int SendTime
        {
            get { return sendTime; }
            set { sendTime = value;
            OnPropertyChanged(new PropertyChangedEventArgs("SendTime"));
            }
        }

        private int qtyXml;
        public int QtyXml
        {
            get { return qtyXml; }
            set { qtyXml = value;
            OnPropertyChanged(new PropertyChangedEventArgs("QtyXml"));
            }
        }

        public AddDevicesSimModel(int qty, int qtyXml, int sendTime)
        {
            this.qty = qty;
            this.qtyXml = qtyXml;
            this.sendTime = sendTime;
        }
    }
}
