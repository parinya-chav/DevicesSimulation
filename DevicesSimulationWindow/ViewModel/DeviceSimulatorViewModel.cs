using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DeviceSimulation.Domain;
using DevicesSimulationWindow.Model;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using DevicesSimulationWindow.View;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight;
using DevicesSimulationWindow.Design;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Threading;

namespace DevicesSimulationWindow.ViewModel
{
    public class DeviceSimulatorViewModel : ViewModelBase
    {
        IDeviceSimulatorService _deviceSimulatorService;

        ObservableCollection<SimDeviceViewModel> _simDeviceList;
        SimDeviceViewModel _selectedSimDevice;

        AddSimDevicesViewModel _addSimDevicesViewModel;
        ObservableCollection<StatusWorkingModel> _statusWorkingList;

        RelayCommand showAddCommand;
        RelayCommand selectAllCommand;
        RelayCommand startCommand;
        RelayCommand pauseCommand;
        RelayCommand stopCommand;
        RelayCommand saveCommand;

        bool selectAllIsChecked;

        private string _iconStartProperty;
        private string _iconPauseProperty;
        private string _iconStopProperty;

        public DeviceSimulatorViewModel(IDeviceSimulatorService deviceSimulatorService, 
                                        AddSimDevicesViewModel addSimDevicesViewModel,
                                        SimDeviceViewModel simDeviceViewModel)
        {
            _deviceSimulatorService = deviceSimulatorService;
            _addSimDevicesViewModel = addSimDevicesViewModel;
            _selectedSimDevice = simDeviceViewModel;

            //Default Add device win
            _addSimDevicesViewModel.Qty = 10;
            _addSimDevicesViewModel.QtyXml = 5;
            _addSimDevicesViewModel.SendTime = 2;

            //_simDeviceList = simDeviceList;
            _simDeviceList = new ObservableCollection<SimDeviceViewModel>();
            //Load default all data
            //_simDeviceList = _deviceSimulatorService.LoadAllSimDeviceViewModel();

            _statusWorkingList = deviceSimulatorService.GetAllStatusWorking();
            
            //Set pic control
            IconStartProperty = "Start-Disabled-icon.png";
            IconPauseProperty = "Pause-Disabled-icon.png";
            IconStopProperty = "Stop-Disabled-icon.png";


            SendCommand = new RelayCommand(Send, new Func<bool>(() =>
            {
                if (SelectedSimDevice == null) return false;
                return !string.IsNullOrEmpty(SelectedSimDevice.Imei);
            }));
        }
        
        public string IconStartProperty
        {
            get { return _iconStartProperty; }
            set
            {
                _iconStartProperty = value;
                RaisePropertyChanged("IconStartProperty");
            }
        }
        public string IconPauseProperty
        {
            get { return _iconPauseProperty; }
            set
            {
                _iconPauseProperty = value;
                RaisePropertyChanged("IconPauseProperty");
            }
        }
        public string IconStopProperty
        {
            get { return _iconStopProperty; }
            set
            {
                _iconStopProperty = value;
                RaisePropertyChanged("IconStopProperty");
            }
        }
        public ObservableCollection<SimDeviceViewModel> SimDeviceList
        { 
            get 
            {
                return _simDeviceList; 
            }            
        }
        public SimDeviceViewModel SelectedSimDevice
        {
            get { return _selectedSimDevice; }
            set { 
                _selectedSimDevice = value;
                RaisePropertyChanged("SelectedSimDevice");
            }
        }
        public ObservableCollection<StatusWorkingModel> StatusWorkingList
        {
            get { return _statusWorkingList; }
            set
            {
                _statusWorkingList = value;
                RaisePropertyChanged("StatusWorkingList");
            }
        }
        public bool SelectAllIsChecked
        {
            get { return selectAllIsChecked; }
            set { selectAllIsChecked = value; }
        }
        public RelayCommand SendCommand { get; private set; }        
        public RelayCommand ShowAddViewCmd
        {
            get
            {
                if (showAddCommand == null)
                {
                    showAddCommand = new RelayCommand(ShowAddDialog, null);
                }
                return showAddCommand;
            }
        }

        public RelayCommand StartCommand
        {
            get
            {
                if (startCommand == null)
                {
                    startCommand = new RelayCommand(Start, ValidStart);
                }
                return startCommand;
            }
        }
        public RelayCommand PauseCommand
        {
            get
            {
                if (pauseCommand == null)
                {
                    pauseCommand = new RelayCommand(Pause, new Func<bool>(()
                        =>
                        {
                            return false;
                        }));
                }
                return pauseCommand;
            }
        }
        public RelayCommand StopCommand
        {
            get
            {
                if (stopCommand == null)
                {
                    stopCommand = new RelayCommand(Stop, new Func<bool>(()
                        =>
                    {
                        return false;
                    }));
                }
                return stopCommand;
            }
        }
        public RelayCommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new RelayCommand(Save, new Func<bool>(()
                        =>
                    {
                        return true;
                    }));
                }
                return saveCommand;
            }
        }

        public void Save()
        {
            var success = _deviceSimulatorService.SaveSimDevices(SimDeviceList);
            if (success)
            {
                MessageBox.Show("Save Success!!");
            }
            else
            {
                MessageBox.Show("Save Failure!!");
            }
        }
        public void Stop()
        {
        }
        public void Pause()
        {            
        }
        public bool ValidStart()
        {
            if (SimDeviceList != null)
            {
                if (SimDeviceList.Where(i => i.IsCheckChoose == true).Count() > 0)
                {
                    IconStartProperty = "Start-icon.png";
                    return true;                    
                }
            }
            IconStartProperty = "Start-Disabled-icon.png";
            return false;
        }
        public void Start()
        {
            try
            {
                var itemsSelect = SimDeviceList.Where(i => i.IsCheckChoose == true);

                var tasks = new List<Task>();
                
                foreach (var item in itemsSelect)
                {
                    item.IsCheckChoose = false;
                    item.Status = 1;

                    var selected = item;

                    var task = new Task(() =>
                        {
                            while (selected.SendComplete < selected.SendTotal)
                            {
                                selected.SendPacket();
                                //Call service...
                                var msg = _deviceSimulatorService.SendPacket();

                                selected.CheckSetAllComplete();
                                selected.Description = msg;

                                Thread.Sleep(TimeSpan.FromSeconds(selected.SendTime));
                            }
                        });

                    tasks.Add(task);
                }

                foreach (var item in tasks)
                {
                    item.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: {0}", ex.Message);
            }
        }

        private void Send()
        {
            MessageBox.Show(SelectedSimDevice.IsCheckChoose.ToString());
        }        
        private void ShowAddDialog()
        {            
            var view = new AddSimDevicesView();
            view.DataContext = _addSimDevicesViewModel;
            view.ShowDialog();

            if (_addSimDevicesViewModel.IsAdd)
            {
                var newDevices = _deviceSimulatorService.AddDevices(_addSimDevicesViewModel.Qty, _addSimDevicesViewModel.QtyXml, _addSimDevicesViewModel.SendTime);
                foreach (var item in newDevices)
                {
                    SimDeviceList.Add(item);
                }

            }
            _addSimDevicesViewModel.Reset();
        }
        public RelayCommand SelectAllCommand
        {
            get
            {
                if (selectAllCommand == null)
                {
                    selectAllCommand = new RelayCommand(SelectAll, ValidSelectAll);
                }
                return selectAllCommand;
            }
        }
        public bool ValidSelectAll()
        {
            if (SimDeviceList != null && SimDeviceList.Count() > 0)
                return true;
            return false;
        }
        public void SelectAll()
        {
            foreach (var item in SimDeviceList)
            {
                item.IsCheckChoose = !item.IsCheckChoose;

            }
        }
        

    }
}
