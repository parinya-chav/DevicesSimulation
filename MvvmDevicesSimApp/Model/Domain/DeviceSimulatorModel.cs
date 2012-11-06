using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevicesSimulationApp.Model.Domain
{
    public class DeviceSimulatorModel
    {
        public DeviceSimulatorModel() 
        { }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Title { get; set; }
    }
}
