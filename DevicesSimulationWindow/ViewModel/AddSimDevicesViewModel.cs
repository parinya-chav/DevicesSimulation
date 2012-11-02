using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeviceSimulation.Domain;
using DevicesSimulationWindow.Model;
using DevicesSimulationWindow.View;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;

namespace DevicesSimulationWindow.ViewModel
{
    public class AddSimDevicesViewModel : ViewModelBase
    {
        private static AddSimDevicesViewModel _originalValue;
        private static int _defaultSendTime = 5;
        static AddSimDevicesViewModel()
        {
            if (_originalValue == null)
            {
                _originalValue = new AddSimDevicesViewModel
                    {
                        qty = 0,
                        qtyXml = 0,
                        sendTime = 0,
                        isAdd = false
                    };
            }
        }

        public AddSimDevicesViewModel()
        {
            
        }
        private int qty;
        private int sendTime;
        private int qtyXml;
        private ICommand addCommand;
        private ICommand cancelCommand;
        private ICommand defaultTimeCommand;

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

        public void Reset()
        {
            Qty = _originalValue.Qty;
            SendTime = _originalValue.SendTime;
            QtyXml = _originalValue.QtyXml;
            isAdd = _originalValue.IsAdd;
        }        

        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(Add, ValidAdd);
                }
                return addCommand;
            }
        }
        public ICommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                {
                    cancelCommand = new RelayCommand(Cancel, null);
                }
                return cancelCommand;
            }
        }
        public ICommand DefaultTimeCommand
        {
            get
            {
                if (defaultTimeCommand == null)
                {
                    defaultTimeCommand = new RelayCommand(Add, ValidAdd);
                }
                return defaultTimeCommand;
            }
        }
        public void Add()
        {
            IsAdd = true;
            if (IsDefaultTime)
                sendTime = _defaultSendTime;
        }
        public bool ValidAdd()
        {
            if (Qty < 1 || QtyXml < 1)
                return false;   
         
            return true;
        }
        public void Cancel()
        {
            IsAdd = false;
        }
        public void DefaultTime()
        {
            
        }
        
    }
}
