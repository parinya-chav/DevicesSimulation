using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using DevicesSimulationWindow.Model;

namespace DevicesSimulationWindow.ViewModel
{
    public class SimDeviceViewModel : ViewModelBase
    {
        public SimDeviceViewModel()
        { }

        private int _id;

        private string _imei;
        private string _description;
        private byte _status;
        public int _sendTime { get; set; }
        public int _sendComplete { get; set; }
        public int _sendTotal { get; set; }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RaisePropertyChanged("Id");
            }
        }
        public string Imei
        {
            get
            {
                return _imei;
            }
            set
            {
                _imei = value;
                RaisePropertyChanged("Imei");
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }
        public byte Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                RaisePropertyChanged("Status");
            }
        }        
        public int SendTime
        {
            get
            {
                return _sendTime;
            }
            set
            {
                _sendTime = value;
                RaisePropertyChanged("SendTime");
            }
        }
        public int SendComplete
        {
            get
            {
                return _sendComplete;
            }
            set
            {
                _sendComplete = value;
                RaisePropertyChanged("SendComplete");
            }
        }
        public int SendTotal
        {
            get
            {
                return _sendTotal;
            }
            set
            {
                _sendTotal = value;
                RaisePropertyChanged("SendTotal");
            }
        }

        public void SendPacket()
        {
            ++SendComplete;
        }
                
        public void CheckSetAllComplete()
        {
            if (SendComplete == SendTotal)
            {
                this.Finish();
            }
        }

        public virtual bool Play()
        {
            if (Status == 0 || Status == 3)
            {
                Status = 1;
                return true;
            }
            return false;
        }
       
        public virtual bool Finish()
        {
            if (Status == 1)
            {
                Status = 3;
                return true;
            }
            return false;
        }

        public virtual bool Pause()
        {
            if (Status == 1)
            {
                Status = 2;
                return true;
            }
            if (Status == 2)
            {
                Status = 1;
                return true;
            }
            return false;
        }

        public virtual bool Continue()
        {
            if (Status == 2)
            {
                Status = 1;
                return true;
            }
            return false;
        }
    }
}
