using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GalaSoft.MvvmLight;
using MvvmDevicesSimApp.Model.View;
using MvvmDevicesSimApp.Model;
using System.Collections.ObjectModel;

namespace MvvmDevicesSimApp.ViewModel
{
    public class DeviceSimulateViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        private DevicesSimulationView _deviceSimu;
        ObservableCollection<DeviceSimulateView> _devices;

        public DevicesSimulationView DeviceSim
        {
            get { return _deviceSimu; }
            set
            {
                if (_deviceSimu != value)
                {
                    _deviceSimu = value;
                    //OnNotifyPropertyChanged("DeviceSimulateView");
                }
            }
        }

        public ObservableCollection<DeviceSimulateView> Devices
        {
            get
            {
                return _devices;
            }
            set
            {
                if (_devices != value)
                {
                    _devices = value;
                    //OnNotifyPropertyChanged("Device");
                }
            }

        }        

        public DeviceSimulateViewModel()
        {
            _dataService = new DataService();
            _deviceSimu = new DevicesSimulationView();
            _devices = new ObservableCollection<DeviceSimulateView>();

            GetDevicesSimulation();
        }

        public void GetDevicesSimulation()
        {
            //_dataService.GetDevices((item, error) =>
            //    {
            //        if (error != null)
            //        {
            //            return;
            //        }
            //        object tmp = item.ObjectData;
            //        var temp = (System.Collections.ObjectModel.ObservableCollection<DeviceSimulateView>)(item.ObjectData[0]);

            //        this.Devices = temp;
            //    });       
            _devices = new ObservableCollection<DeviceSimulateView>();
            _devices.Add(new DeviceSimulateView { Name = "1"});
            _devices.Add(new DeviceSimulateView { Name = "2" });
            _devices.Add(new DeviceSimulateView { Name = "3" });
        }

        public void UpdatePerson()
        {

        }    
                        
    }
}
