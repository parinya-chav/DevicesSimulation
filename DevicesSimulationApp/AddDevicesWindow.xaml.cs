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

using DevicesSimulationApp.Models;

namespace DevicesSimulationApp
{
    /// <summary>
    /// Interaction logic for AddDevicesWindow.xaml
    /// </summary>
    public partial class AddDevicesWindow : Window
    {
        private AddDevicesSimModel addDevices;
        public AddDevicesSimModel AddDevices
        {
            get { return addDevices; }
            set { addDevices = value; }
        }

        public AddDevicesWindow()
        {
            InitializeComponent();
            addDevices = new AddDevicesSimModel(10,10,2);
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)cmdCheckDefault.IsChecked)
            {
                addDevices.SendTime = 5;
            }

            DialogResult = true;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gridAddDevices.DataContext = addDevices;
        }

        private void cmdCheckDefault_Checked(object sender, RoutedEventArgs e)
        {
            tbSendTime.IsReadOnly = true;
        }

        private void cmdCheckDefault_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void titleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
