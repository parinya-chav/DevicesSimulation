using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevicesSimulationApp.Models
{
    public class StatusModel
    {
        private int statusID;
        public int StatusID
        {
            get { return statusID; }
            set { statusID = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }           
    }
}
