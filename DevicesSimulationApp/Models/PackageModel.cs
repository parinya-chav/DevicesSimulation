using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DevicesSimulationApp.Models
{
    public class PackageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
        public PackageModel()
        { }
        
        private int sequence;
        public int Sequence
        {
            get { return sequence; }
            set { sequence = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Sequence"));
            }
        }

        private string messageType;
        public string MessageType
        {
            get { return messageType; }
            set { messageType = value;
            OnPropertyChanged(new PropertyChangedEventArgs("MessageType"));
            }
        }

        private int status;
        public int Status
        {
            get { return status; }
            set { status = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Status"));
            }
        }
        
    }
}
