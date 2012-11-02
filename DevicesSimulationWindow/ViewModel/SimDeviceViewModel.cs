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

        private bool _isCheckChoose;
        private string _imei;
        private string _description;
        private byte _status;
        public bool _isFinish { get; set; }
        public int _sendTime { get; set; }
        public int _sendComplete { get; set; }
        public int _sendTotal { get; set; }

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
        public bool IsCheckChoose 
        {
            get
            {
                return _isCheckChoose;
            }
            set
            {
                _isCheckChoose = value;
                RaisePropertyChanged("IsCheckChoose");
            }
        }
        public bool IsFinish
        {
            get
            {
                return _isFinish;
            }
            set
            {
                _isFinish = value;
                RaisePropertyChanged("IsFinish");
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
                IsFinish = true;
        }
    }
}
