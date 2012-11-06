using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using MvvmDevicesSimApp.ViewModel;

namespace MvvmDevicesSimApp
{
    /// <summary>
    /// Interaction logic for DeviceSimulateView.xaml
    /// </summary>
    public partial class DeviceSimulateView : Window
    {
        public DeviceSimulateView()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
    }
}
