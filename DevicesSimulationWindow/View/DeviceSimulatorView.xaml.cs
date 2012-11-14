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

using GalaSoft.MvvmLight.Messaging;
using DevicesSimulationWindow.ViewModel;

namespace DevicesSimulationWindow.View
{
    /// <summary>
    /// Interaction logic for DeviceSimulatorView.xaml
    /// </summary>
    public partial class DeviceSimulatorView : Window
    {
        public DeviceSimulatorView()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
            //Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            //if (msg.Notification == "AddDeviceSimView")
            //{
            //    ImageStart.Source = (ImageSource)FindResource("");
            //}
        }        
    }
}
