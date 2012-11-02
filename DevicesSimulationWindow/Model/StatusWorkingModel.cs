using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GalaSoft.MvvmLight;

namespace DevicesSimulationWindow.Model
{
    public class StatusWorkingModel : ViewModelBase
    {
        private int statusID;
        public int StatusID
        {
            get { return statusID; }
            set { statusID = value;
            RaisePropertyChanged("StatusID");
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value;
            RaisePropertyChanged("Description");
            }
        }
    }
}
