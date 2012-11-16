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

        //AddSimDevicesViewModel _addSimDevicesViewModel;
        HeaderDevicesSimulatorViewModel _headerDevicesSimulatorViewModel;
        LoadDeviceSimulatorViewModel _loadDeviceSimulatorViewModel;

        ObservableCollection<StatusWorkingModel> _statusWorkingList;

        RelayCommand showAddCommand;
        RelayCommand deleteCommand;
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
        
        public DeviceSimulatorViewModel(IDeviceSimulatorService deviceSimulatorService, 
                                        SimDeviceViewModel simDeviceViewModel,
                                        HeaderDevicesSimulatorViewModel addDevicesSimulatorNameViewModel,
                                        LoadDeviceSimulatorViewModel loadDeviceSimulatorViewModel)
        {
            _deviceSimulatorService = deviceSimulatorService;
            _selectedSimDevice = simDeviceViewModel;
            _headerDevicesSimulatorViewModel = addDevicesSimulatorNameViewModel;
            _loadDeviceSimulatorViewModel = loadDeviceSimulatorViewModel;

            //Default Add device win
            _headerDevicesSimulatorViewModel.Qty = 10;
            _headerDevicesSimulatorViewModel.QtyXml = 5;
            _headerDevicesSimulatorViewModel.SendTime = 2;

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
        private ICommand deleteSimDeviceCommand;
        public ICommand DeleteSimDeviceCommand
        {
            get
            {
                if (deleteSimDeviceCommand == null)
                {
                    deleteSimDeviceCommand = new RelayCommand(deleteSimDeviceCmd);
                }
                return deleteSimDeviceCommand;
            }
        }
        private void deleteSimDeviceCmd()
        {
            if (SelectedSimDevice.Id != 0)
            {
                _deviceSimulatorService.DeleteSimDevices(_headerDevicesSimulatorViewModel.ID, SelectedSimDevice.Id);
                SimDeviceList.Remove(SelectedSimDevice);
            }
        }
        
        public RelayCommand SendCommand { get; private set; }
        public RelayCommand NewCommand
        {
            get
            {
                if (newCommand == null)
                {
                    newCommand = new RelayCommand(newCmd, validNew);
                }
                return newCommand;
            }
        }
        private bool validNew()
        {
            if (_headerDevicesSimulatorViewModel.Status != 1)
            {
                return true;
            }
            return false;
        }
        public void Reset()
        {
            _simDeviceList.Clear();
            _headerDevicesSimulatorViewModel.Reset();
            
        }
        private void newCmd()
        {
            Reset();
        }
        public RelayCommand AddCommand
        {
            get
            {
                if (showAddCommand == null)
                {
                    showAddCommand = new RelayCommand(ShowAddDialog, validAddDialog);
                }
                return showAddCommand;
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(deleteSimDeviceCmd
                        , new Func<bool>(() =>
                                        {
                                            if(SelectedSimDevice != null &&
                                                SelectedSimDevice.Id != 0)
                                                return true;
                                            return false;
                                        }));
                }
                return deleteCommand;
            }
        }
        

        private bool validAddDialog()
        {
            if (_headerDevicesSimulatorViewModel.ID == 0)
                return true;
            return false;
        }

        public RelayCommand StartCommand
        {
            get
            {
                if (startCommand == null)
                {
                    startCommand = new RelayCommand(Start, validStart);
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
                    pauseCommand = new RelayCommand(Pause, validPause);
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
                    stopCommand = new RelayCommand(Stop, validStop);
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
                    openCommand = new RelayCommand(Open, validOpen);
                }
                return openCommand;
            }
        }
        private bool validOpen()
        {
            if (_headerDevicesSimulatorViewModel.Status != 1)
            {
                return true;
            }
            return false;
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
            _headerDevicesSimulatorViewModel.Status = loadDevices.Status;

            SimDeviceList.Clear();
            foreach (var item in loadDevices.SimDeviceViewModel)
            {
                SimDeviceList.Add(item);
            }
            
        }
        public void BeforeClose()
        {
            if (_headerDevicesSimulatorViewModel.Status == 1)
            {
                IsRunning = false;
                if (_simDeviceList != null && _simDeviceList.Count() > 0)
                {
                    var items = _simDeviceList.Where(i => i.Status == 1);
                    foreach (var item in items)
                    {
                        item.Status = 2;
                    }
                    _headerDevicesSimulatorViewModel.Status = 2;

                    Save();
                }
            }
        }
        public void Save()
        {
            int checkId = 0;

            if (_headerDevicesSimulatorViewModel.ID == 0)
            {                
                checkId = _deviceSimulatorService.SaveSimDevices(SimDeviceList, _headerDevicesSimulatorViewModel);
                if (checkId != 0)
                {
                    _headerDevicesSimulatorViewModel.ID = checkId;
                    getSimDevicesByDeviceSimulatorId(checkId);
                }
                else
                {
                    MessageBox.Show("Save Failure!!");
                }
                
            }
            else
            {
                checkId = _deviceSimulatorService.SaveSimDevices(SimDeviceList, _headerDevicesSimulatorViewModel);
                if (checkId != 0)
                {
                    //getSimDevicesByDeviceSimulatorId(checkId);                    
                }
                else
                {
                    MessageBox.Show("Save Failure!!");
                }
            }
        }
        private bool validSave()
        {
            //bool chk = false;

            //chk = _isChange;
            
            //if(chk)
            //    IconSaveProperty = "Save-icon.png";
            //else
            //    IconSaveProperty = "Save-disable-icon.png";

            return false;
        }
        private void showAddDeviceSimulatorName()
        {
            var view = new AddDeviceSimulatorNameView();
            view.DataContext = _headerDevicesSimulatorViewModel;
            view.ShowDialog();
        }
        public void Stop()
        {
            _headerDevicesSimulatorViewModel.Status = 0;
            resetSimDevice();
            Save();

            IsRunning = false;
        }
        public void Pause()
        {
            if (_headerDevicesSimulatorViewModel.Status == 1 || _headerDevicesSimulatorViewModel.Status == 2)
            {
                if (_headerDevicesSimulatorViewModel.Status == 1)
                    _headerDevicesSimulatorViewModel.Status = 2;
                else
                    _headerDevicesSimulatorViewModel.Status = 1;
                
                IsRunning = !IsRunning;
                if (IsRunning)
                {
                    taskManage();
                }
                else
                {
                    var itemsSelect = SimDeviceList.Where(i => i.Status != 3);

                    foreach (var item in itemsSelect)
                    {
                        item.Pause();
                    }

                    Save();
                }
                
            }
        }
        private bool validStop()
        {
            //if (IsRunning)
            //{
            //    IconStopProperty = "Stop-icon.png";
            //    return true;
            //}
            //else
            //{
            //    IconStopProperty = "Stop-Disabled-icon.png";
            //    return false;
            //}
            if (_headerDevicesSimulatorViewModel.ID != 0)
                return true;
            return false;
        }
        private bool validPause()
        {
            if (_headerDevicesSimulatorViewModel.Status == 1 || _headerDevicesSimulatorViewModel.Status == 2)
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
        public bool validStart()
        {
            if (SimDeviceList != null && !IsRunning)
            {
                if (_headerDevicesSimulatorViewModel.Status == 0 || _headerDevicesSimulatorViewModel.Status == 3)
                {
                    if (SimDeviceList.Count() > 0)
                    {
                        if (SimDeviceList.Where(i => i.Status == 0).Count() > 0 ||
                            SimDeviceList.Where(i => i.Status == 3).Count() == SimDeviceList.Count())
                        {
                            IconStartProperty = "Start-icon.png";
                            return true;
                        }
                    }
                }
            }
            IconStartProperty = "Start-Disabled-icon.png";
            return false;
        }

        private bool _isRunning = false;

        public bool IsRunning
        {
            get { return _isRunning; }
            set { _isRunning = value;
            RaisePropertyChanged("IsRunning");
            }
        }
        
        public void Start()
        {
            if (_headerDevicesSimulatorViewModel.Status == 0 || _headerDevicesSimulatorViewModel.Status == 3)
            {                
                IsRunning = true;

                if (_headerDevicesSimulatorViewModel.Status == 3)
                {
                    resetSimDevice();
                }
                _headerDevicesSimulatorViewModel.Status = 1;
                Save();

                taskManage();
            }
        }
        private void taskManage()
        {
            var simTask = new Task(() =>
            {
                try
                {
                    var itemsSelect = SimDeviceList.Where(i => i.Status != 3);
                    var tasks = new List<Task>();

                    foreach (var item in itemsSelect)
                    {
                        if (item.Play() || item.Pause())
                        {
                            var selected = item;

                            var task = new Task(() =>
                            {
                                while (selected.SendComplete < selected.SendTotal && IsRunning)
                                {
                                    selected.SendPacket();
                                    selected.CheckSetAllComplete();

                                    //Call service...
                                    var msg = _deviceSimulatorService.SendPacket(selected);

                                    selected.Description = msg;

                                    Thread.Sleep(TimeSpan.FromSeconds(selected.SendTime));
                                }
                                //selected.Status = 0;
                            });

                            tasks.Add(task);
                        }
                    }

                    foreach (var item in tasks)
                    {
                        item.Start();
                    }

                    Task.WaitAll(tasks.ToArray());
                    
                    if (SimDeviceList.Where(i => i.Status == 3).Count().Equals(SimDeviceList.Count()))
                    {
                        _headerDevicesSimulatorViewModel.Status = 3;
                        Save();
                    }
                    IsRunning = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: {0}", ex.Message);
                }
            });

            simTask.Start();
        }
        
        private void resetSimDevice()
        {
            foreach (var item in SimDeviceList)
            {
                item.Status = 0;
                item.Description = "";
                item.SendComplete = 0;
            }

        }
        private void Send()
        {
            MessageBox.Show(SelectedSimDevice.ToString());
        }        
        private void ShowAddDialog()
        {            
            //var view = new AddSimDevicesView();
            //view.DataContext = _addSimDevicesViewModel;
            //view.ShowDialog();

            var view = new AddDeviceSimulatorNameView();
            view.DataContext = _headerDevicesSimulatorViewModel;
            view.ShowDialog();

            if (_headerDevicesSimulatorViewModel.IsOK)
            {
                var newDevices = _deviceSimulatorService.AddDevices(_headerDevicesSimulatorViewModel.Qty
                                                            , _headerDevicesSimulatorViewModel.QtyXml
                                                            , _headerDevicesSimulatorViewModel.SendTime);
                foreach (var item in newDevices)
                {
                    SimDeviceList.Add(item);
                }

                Save();

            }
            //_headerDevicesSimulatorViewModel.Reset();
        }               

    }
}
