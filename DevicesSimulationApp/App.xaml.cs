using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

using DevicesSimulationApp.Services;

namespace DevicesSimulationApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ManageDevices manageDevices = new ManageDevices();
        public static ManageDevices ManageDevices
        {
            get { return manageDevices; }
        }
    }
}
