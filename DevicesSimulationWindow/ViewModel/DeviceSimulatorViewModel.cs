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
        
        bool selectAllIsChecked;
        
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

            SendCommand = new RelayCommand(Send, new Func<bool>(() =>
            {
                if (SelectedSimDevice == null) return false;
                return !string.IsNullOrEmpty(SelectedSimDevice.Imei);
            }));
        }

        public string ViewModelEnumProperty
        {
            get;
            set;
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
        public bool ValidStart()
        {
            if (SimDeviceList != null)
            {
                if (SimDeviceList.Where(i => i.IsCheckChoose == true).Count() > 0)
                {
                    ViewModelEnumProperty = "Abled";
                    return true;                    
                }
            }

            ViewModelEnumProperty = "Disabled";
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
                    selectAllCommand = new RelayCommand(SelectAll,null);
                }
                return selectAllCommand;
            }
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
