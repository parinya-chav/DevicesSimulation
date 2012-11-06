using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DevicesSimulationApp.Models
{
    public class SimDeviceModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public SimDeviceModel()
        {}

        private IList<PackageModel> packageModel;
        public IList<PackageModel> PackageModel
        {
            get { return packageModel; }
            set { packageModel = value;
            OnPropertyChanged(new PropertyChangedEventArgs("PackageModel"));
            }
        }

        private string imei;
        public string Imei
        {
            get { return imei; }
            set { imei = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Imei"));
            }
        }

        /// <summary>
        /// 0 = Inactive, 1 = Active
        /// </summary>
        private byte status;
        public byte Status
        {
            get { return status; }
            set { status = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Status"));
            }
        }

        private bool finish;
        public bool Finish
        {
            get { return finish; }
            set
            {
                finish = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Finish"));
            }
        }

        /// <summary>
        /// sendTime (s)
        /// </summary>
        private int sendTime;
        public int SendTime
        {
            get { return sendTime; }
            set { sendTime = value;
            OnPropertyChanged(new PropertyChangedEventArgs("SendTime"));
            }
        }

        private bool checkChoose;
        public bool CheckChoose
        {
            get { return checkChoose; }
            set
            {
                checkChoose = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CheckChoose"));
            }
        }

        private int sendComplete;
        public int SendComplete
        {
            get { return sendComplete; }
            set 
            { 
                sendComplete = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SendComplete"));
            }
        }
        public void SendPacket()
        {
            ++SendComplete;
        }

        public void CheckSetAllComplete()
        {
            if (sendComplete == sendTotal)
            {
                Finish = true;
                Description = "Completed";
            }
        }

        private int sendTotal;
        public int SendTotal
        {
            get { return sendTotal; }
            set { sendTotal = value;
            OnPropertyChanged(new PropertyChangedEventArgs("SendTotal"));
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Description"));
            }
        }

    }
}
