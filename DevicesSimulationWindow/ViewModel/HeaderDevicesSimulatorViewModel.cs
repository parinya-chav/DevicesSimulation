using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace DevicesSimulationWindow.ViewModel
{
    public class HeaderDevicesSimulatorViewModel : ViewModelBase
    {
        private static HeaderDevicesSimulatorViewModel _originalValue;
        private static int _defaultSendTime = 5;

        static HeaderDevicesSimulatorViewModel()
        {
            if (_originalValue == null)
            {
                _originalValue = new HeaderDevicesSimulatorViewModel
                    {
                        isOK = false,
                        ID = 0,
                        HeadName = "",
                        Status = 0
                    };
            }
        }
        public HeaderDevicesSimulatorViewModel()
        {            
        }

        private int _id;
        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        private string _name;
        public string HeadName 
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private byte _status;
        public byte Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        private int qty;
        private int sendTime;
        private int qtyXml;

        private bool isAdd;
        private bool isDefaultTime;

        public bool IsAdd
        {
            get { return isAdd; }
            private set { isAdd = value; }
        }
        public bool IsDefaultTime
        {
            get { return isDefaultTime; }
            set { isDefaultTime = value; }
        }
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

        private ICommand okCommand;
        private ICommand cancelCommand;

        private bool isOK;

        public bool IsOK
        {
            get { return isOK; }
            private set { isOK = value; }
        }

        public ICommand OkCommand
        {
            get
            {
                if (okCommand == null)
                {
                    okCommand = new RelayCommand(Ok, ValidOk);
                }
                return okCommand;
            }
        }
        public ICommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                {
                    cancelCommand = new RelayCommand(Cancel);
                }
                return cancelCommand;
            }
        }
        public void Ok()
        {
            IsOK = true;
            if (IsDefaultTime)
                sendTime = _defaultSendTime;
        }
        public bool ValidOk()
        {
            if (HeadName == null || 
                HeadName.Equals("") ||
                Qty < 1 || 
                QtyXml < 1)
                return false;

            return true;
        }
        public void Cancel()
        {
            IsOK = false;
        }
        public void Reset()
        {
            isOK = _originalValue.isOK;
            ID = _originalValue.ID;
            HeadName = _originalValue.HeadName;
            Status = _originalValue.Status;
        }  
       
    }
}
