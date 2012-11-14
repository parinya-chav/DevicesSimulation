/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:DevicesSimulationWindow.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using DevicesSimulationWindow.Model;
using DeviceSimulation.Domain;
using DevicesSimulationWindow.Design;
using DevicesSimulationWindow.View;
using System.Collections.ObjectModel;

namespace DevicesSimulationWindow.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            //}
            //else
            //{
            //    SimpleIoc.Default.Register<IDataService, DataService>();
            //}

            SimpleIoc.Default.Register<IDeviceSimulatorService, DeviceSimulatorServiceAgent>();
            
            SimpleIoc.Default.Register<DeviceSimulatorViewModel>();
            //SimpleIoc.Default.Register<AddSimDevicesViewModel>();
            SimpleIoc.Default.Register<SimDeviceViewModel>();
            SimpleIoc.Default.Register<StatusWorkingModel>();
            SimpleIoc.Default.Register<HeaderDevicesSimulatorViewModel>();
            SimpleIoc.Default.Register<LoadDeviceSimulatorViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public DeviceSimulatorViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DeviceSimulatorViewModel>();
            }
        }

        public SimDeviceViewModel SimDevice
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SimDeviceViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            ServiceLocator.Current.GetInstance<DeviceSimulatorViewModel>().BeforeClose();
        }
    }
}