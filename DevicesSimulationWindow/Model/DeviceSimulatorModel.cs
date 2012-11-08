using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevicesSimulationWindow.ViewModel;

namespace DevicesSimulationWindow.Model
{
    public class DeviceSimulatorModel
    {
        private int _id;
        private string _description;

        private IList<SimDeviceViewModel> _simDeviceViewModel;

        public DeviceSimulatorModel()
        {
            _simDeviceViewModel = new List<SimDeviceViewModel>();
        }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                //RaisePropertyChanged("StatusID");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
            }
        }

        public IList<SimDeviceViewModel> SimDeviceViewModel
        {
            get { return _simDeviceViewModel; }
            set
            {
                _simDeviceViewModel = value;
            }
        }
    }
}
