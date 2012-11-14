using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GalaSoft.MvvmLight;
using DevicesSimulationWindow.Model;
using DevicesSimulationWindow.Design;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace DevicesSimulationWindow.ViewModel
{
    public class LoadDeviceSimulatorViewModel : ViewModelBase
    {
        IDeviceSimulatorService _deviceSimulatorService;

        IList<DeviceSimulatorModel> _deviceSimulatorList;
        DeviceSimulatorModel _selectDeviceSim;
        ICommand _okCommand;
        ICommand _cancelCommand;
        ICommand _getCommand;
        bool _isChoose;

        public LoadDeviceSimulatorViewModel(IDeviceSimulatorService deviceSimulatorService)
        {
            _deviceSimulatorService = deviceSimulatorService;
            //_deviceSimulatorList = _deviceSimulatorService.GetAllDeviceSimulator();
        }
        
        public IList<DeviceSimulatorModel> DeviceSimulatorList
        {
            get
            {
                return _deviceSimulatorList;
            }
            set
            {
                _deviceSimulatorList = value;
            }
        }
        public DeviceSimulatorModel SelectDeviceSim
        {
            get
            {
                return _selectDeviceSim;
            }
            set
            {
                _selectDeviceSim = value;
                RaisePropertyChanged("SelectDeviceSim");
            }
        }
        public bool IsChoose
        {
            get { return _isChoose; }
            private set { _isChoose = value; 
                
            }
        }

        public ICommand OkCommand
        {
            get
            {
                if (_okCommand == null)
                {
                    _okCommand = new RelayCommand(choose, validChoose);
                }
                return _okCommand;
            }
        }
        private bool validChoose()
        {
            if(SelectDeviceSim != null)
                return true;

            return false;
        }
        private void choose()
        {
            IsChoose = true;
        }
        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new RelayCommand(noChoose);
                }
                return _cancelCommand;
            }
        }
        private void noChoose()
        {
            IsChoose = false;
        }

        public void Reset()
        {
            _isChoose = false;
            _selectDeviceSim = null;
            _deviceSimulatorList = null;
        }   
    }
}
