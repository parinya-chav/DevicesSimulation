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
        HeaderDevicesSimulatorViewModel _headerDevicesSimulatorViewModel;
        LoadDeviceSimulatorViewModel _loadDeviceSimulatorViewModel;

        ObservableCollection<StatusWorkingModel> _statusWorkingList;

        RelayCommand showAddCommand;
        RelayCommand selectAllCommand;
        RelayCommand startCommand;
        RelayCommand pauseCommand;
        RelayCommand stopCommand;
        RelayCommand saveCommand;
        RelayCommand openCommand;
        RelayCommand newCommand;

        bool _isSelectAll;
        private string _iconSaveProperty;
        private string _iconStartProperty;
        private string _iconPauseProperty;
        private string _iconStopProperty;
        bool _isChange;
        public DeviceSimulatorViewModel(IDeviceSimulatorService deviceSimulatorService, 
                                        AddSimDevicesViewModel addSimDevicesViewModel,
                                        SimDeviceViewModel simDeviceViewModel,
                                        HeaderDevicesSimulatorViewModel addDevicesSimulatorNameViewModel,
                                        LoadDeviceSimulatorViewModel loadDeviceSimulatorViewModel)
        {
            _deviceSimulatorService = deviceSimulatorService;
            _addSimDevicesViewModel = addSimDevicesViewModel;
            _selectedSimDevice = simDeviceViewModel;
            _headerDevicesSimulatorViewModel = addDevicesSimulatorNameViewModel;
            _loadDeviceSimulatorViewModel = loadDeviceSimulatorViewModel;

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
            _iconSaveProperty = "Save-disable-icon.png";
            IconStartProperty = "Start-Disabled-icon.png";
            IconPauseProperty = "Pause-Disabled-icon.png";
            IconStopProperty = "Stop-Disabled-icon.png";


            SendCommand = new RelayCommand(Send, new Func<bool>(() =>
            {
                if (SelectedSimDevice == null) return false;
                return !string.IsNullOrEmpty(SelectedSimDevice.Imei);
            }));
        }

        public string IconOpenProperty
        {
            get { return "Open-icon.png"; }
        }
        public string IconSaveProperty
        {
            get { return _iconSaveProperty; }
            set
            {
                _iconSaveProperty = value;
                RaisePropertyChanged("IconSaveProperty");
            }
        }
        public string IconNewProperty
        {
            get { return "New-file-icon.png"; }            
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
                _isChange = true;
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
            get { return _isSelectAll; }
            set { _isSelectAll = value; }
        }
        public RelayCommand SendCommand { get; private set; }
        public RelayCommand NewCommand
        {
            get
            {
                if (newCommand == null)
                {
                    newCommand = new RelayCommand(newCmd);
                }
                return newCommand;
            }
        }
        public void Reset()
        {
            _simDeviceList.Clear();
            _headerDevicesSimulatorViewModel.Reset();
            _isChange = false;
        }
        private void newCmd()
        {
            Reset();
        }
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
                    pauseCommand = new RelayCommand(Pause, ValidPause);
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
                    stopCommand = new RelayCommand(Stop, ValidStop);
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
                    saveCommand = new RelayCommand(Save, validSave);
                }
                return saveCommand;
            }
        }
        public RelayCommand OpenCommand
        {
            get
            {
                if (openCommand == null)
                {
                    openCommand = new RelayCommand(Open);
                }
                return openCommand;
            }
        }
        public void Open()
        {
            var view = new LoadDeviceSimulatorView();
            view.DataContext = _loadDeviceSimulatorViewModel;
            _loadDeviceSimulatorViewModel.DeviceSimulatorList = _deviceSimulatorService.GetAllDeviceSimulator();
            view.ShowDialog();

            if (_loadDeviceSimulatorViewModel.IsChoose)
            {
                getSimDevicesByDeviceSimulatorId(_loadDeviceSimulatorViewModel.SelectDeviceSim.Id);                         
            }
            _loadDeviceSimulatorViewModel.Reset();
        }
        private void getSimDevicesByDeviceSimulatorId(int id)
        {
            var loadDevices = _deviceSimulatorService.getSimDevicesByDeviceSimulatorId(id);

            _headerDevicesSimulatorViewModel.ID = loadDevices.Id;
            _headerDevicesSimulatorViewModel.HeadName = loadDevices.Description;

            SimDeviceList.Clear();
            foreach (var item in loadDevices.SimDeviceViewModel)
            {
                SimDeviceList.Add(item);
            }    
        }
        public void Save()
        {
            int checkId = 0;

            if (_headerDevicesSimulatorViewModel.ID == 0)
            {
                showAddDeviceSimulatorName();

                if (_headerDevicesSimulatorViewModel.IsOK)
                {
                    checkId = _deviceSimulatorService.SaveSimDevices(SimDeviceList, _headerDevicesSimulatorViewModel);
                    if (checkId != 0)
                    {
                        _headerDevicesSimulatorViewModel.ID = checkId;
                        getSimDevicesByDeviceSimulatorId(checkId);
                        MessageBox.Show("Save Success!!");
                    }
                    else
                    {
                        MessageBox.Show("Save Failure!!");
                    }
                }
                else
                {
                    _headerDevicesSimulatorViewModel.Reset();
                }
            }
            else
            {
                checkId = _deviceSimulatorService.SaveSimDevices(SimDeviceList, _headerDevicesSimulatorViewModel);
                if (checkId != 0)
                {
                    getSimDevicesByDeviceSimulatorId(checkId);
                    MessageBox.Show("Save Success!!");
                }
                else
                {
                    MessageBox.Show("Save Failure!!");
                }
            }
        }
        private bool validSave()
        {
            bool chk = false;

            chk = _isChange;
            
            if(chk)
                IconSaveProperty = "Save-icon.png";
            else
                IconSaveProperty = "Save-disable-icon.png";

            return chk;
        }
        private void showAddDeviceSimulatorName()
        {
            var view = new AddDeviceSimulatorNameView();
            view.DataContext = _headerDevicesSimulatorViewModel;
            view.ShowDialog();
        }
        public void Stop()
        {
            IsRunning = false;
        }
        public void Pause()
        {
            IsRunning = false;
        }
        public bool ValidStop()
        {
            if (IsRunning)
            {
                IconStopProperty = "Stop-icon.png";
                return true;
            }
            else
            {
                IconStopProperty = "Stop-Disabled-icon.png";
                return false;
            }
        }
        public bool ValidPause()
        {
            if (IsRunning)
            {
                IconPauseProperty = "Pause-icon.png";
                return true;
            }
            else
            {
                IconPauseProperty = "Pause-Disabled-icon.png";
                return false;
            }
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

        bool IsRunning = false;

        public void Start()
        {
            IsRunning = true;

            var simTask = new Task(() =>
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
                                while (selected.SendComplete < selected.SendTotal && IsRunning)
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

                    Task.WaitAll(tasks.ToArray());
                    IsRunning = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: {0}", ex.Message);
                }
            });

            simTask.Start();
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
                _isChange = true;
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
