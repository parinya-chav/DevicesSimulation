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
using System.Windows.Navigation;
using System.Windows.Shapes;

using DevicesSimulationApp.Models;
using System.Data;
using System.Threading;
using System.Windows.Threading;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DevicesSimulationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DeviceSimulatorModel deviceSimulator;
        public DeviceSimulatorModel DeviceSimulator
        {
            get { return deviceSimulator; }
            set { deviceSimulator = value; }
        }

        private DataRowView rowBeingEdited = null;
        BackgroundWorker worker;  
        public MainWindow()
        {
            InitializeComponent();
            deviceSimulator = new DeviceSimulatorModel();
            deviceSimulator.SimDeviceModel = new List<SimDeviceModel>();
            worker = new BackgroundWorker();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                bindingControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System error!!");
            }
        }
        private void bindingControl()
        {
            gridDevices.ItemsSource = deviceSimulator.SimDeviceModel;
            gridComboStatus.ItemsSource = App.ManageDevices.GetStatusMaster();
        }

        private void cmdAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddDevicesWindow winAdd = new AddDevicesWindow();
                if (winAdd.ShowDialog() == true)
                {
                    var addDevices = winAdd.AddDevices;
                    addDevicesSim(addDevices);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System error!!");
            }
        }

        private void addDevicesSim(AddDevicesSimModel addDevicesSimViewModel)
        {
            var deviceSim = App.ManageDevices.GenerateDevicesSim(addDevicesSimViewModel);
            foreach (var item in deviceSim.SimDeviceModel)
            {
                deviceSimulator.SimDeviceModel.Add(item);
            }

            gridDevices.Items.Refresh();           
        }

        private void selectAllDevices()
        {
            try
            {
                gridDevices.CommitEdit();
                if (deviceSimulator.SimDeviceModel.Count > 0)
                {
                    foreach (var item in deviceSimulator.SimDeviceModel.Where(a => a.Status == 0))
                    {
                        item.CheckChoose = true;                        
                    }
                    if (gridDevices.CommitEdit())
                    {
                        gridDevices.Items.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void unSelectAllDevices()
        {
            try
            {
                gridDevices.CommitEdit();
                if (deviceSimulator.SimDeviceModel.Count > 0)
                {
                    foreach (var item in deviceSimulator.SimDeviceModel)
                    {
                        item.CheckChoose = false;
                    }
                    if (gridDevices.CommitEdit())
                    {
                        gridDevices.Items.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void cmdSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckBox cmb = (CheckBox)sender;
                cmb.Content = "Unselect All";
                
                selectAllDevices();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System error!!");
            }
        }

        private void cmdSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                EndEdit();
                CheckBox cmb = (CheckBox)sender;
                cmb.Content = "Select All";
                unSelectAllDevices();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System error!!");
            }
        }

        private void cmdStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                startDevicesSimlute();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System error!!");
            }
        }

        private void startDevicesSimlute()
        {
            try
            {
                gridDevices.CommitEdit();
                var myList = deviceSimulator.SimDeviceModel.Where(d => d.CheckChoose == true).ToList();
                int count = myList.Count * 10;
               
                var tasks = new List<Task>();

                var itemsSelectd = deviceSimulator.SimDeviceModel.Where(d => d.CheckChoose == true).ToList();
                
                foreach (var item in itemsSelectd)
                {                    
                    item.CheckChoose = false;
                    item.Status = 1;

                    var selected = item;
                    var task = new Task(() =>
                    {
                        Console.WriteLine("Imei: {0}, complete: {1}", selected.Imei, selected.SendComplete);

                        while (selected.SendComplete < selected.SendTotal)
                        {
                            try
                            {
                                selected.SendPacket();
                                string msg = App.ManageDevices.TestStartDevicesSimlute();
                                selected.CheckSetAllComplete();

                                Console.WriteLine("Imei: {0}, complete: {1}", selected.Imei, selected.SendComplete);
                                selected.Description = msg;
                                
                                Thread.Sleep(TimeSpan.FromSeconds(selected.SendTime));
                            }
                            catch (Exception ex)
                            {

                                throw ex;
                            }
                        }
                        //worker.ReportProgress(Convert.ToInt32(((decimal)prog / (decimal)count) * 100));
                    });

                    tasks.Add(task);
                    
                    //gridDevices.ItemsSource = null;
                    //gridDevices.ItemsSource = deviceSimulator.SimDeviceModel;
                }

                foreach (var item in tasks)
                {
                    item.Start();
                }
                //worker.ProgressChanged += delegate(object s, ProgressChangedEventArgs args)
                //{
                //    progress.Value = args.ProgressPercentage;
                //};

                Console.WriteLine("Completed");
                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }       

        private void dataGrid_CellEditEnding(object sender,
                                  DataGridCellEditEndingEventArgs e)
        {
            DataRowView rowView = e.Row.Item as DataRowView;
            rowBeingEdited = rowView;
        }

        private void dataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGrid dd = (DataGrid)sender;
            if (rowBeingEdited != null)
            {
                rowBeingEdited.EndEdit();
            }
        }

        private void EndEdit(DependencyObject parent)
        {
            LocalValueEnumerator localValues = parent.GetLocalValueEnumerator();
            while (localValues.MoveNext())
            {
                LocalValueEntry entry = localValues.Current;
                if (BindingOperations.IsDataBound(parent, entry.Property))
                {
                    BindingExpression binding = BindingOperations.GetBindingExpression(parent, entry.Property);
                    if (binding != null)
                    {
                        binding.UpdateSource();
                    }
                }
                
            }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                this.EndEdit(child);                
            }
        }

        protected void EndEdit()
        {
            //this.EndEdit(this);
        }

        private void cmdStop_Click(object sender, RoutedEventArgs e)
        {
            gridDevices.CommitEdit();
            gridDevices.CommitEdit();
            gridDevices.Items.Refresh();
        }

        private void dataGrid_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void cmdDelete_Click(object sender, RoutedEventArgs e)
        {

        }
                          
                      
        
    }
}
