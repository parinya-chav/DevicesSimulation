using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevicesSimulationWindow.ViewModel;
using DevicesSimulationWindow.Model;
using System.Collections.ObjectModel;

namespace DevicesSimulationWindow.Design
{
    public interface IDeviceSimulatorService
    {
        ObservableCollection<SimDeviceViewModel> LoadAllSimDeviceViewModel();
        IList<SimDeviceViewModel> AddDevices(int qtyDevices, int qtyXml, int sendTime);
        ObservableCollection<StatusWorkingModel> GetAllStatusWorking();
        string SendPacket(SimDeviceViewModel simDeviceViewModel);
        int SaveSimDevices(ObservableCollection<SimDeviceViewModel> simDeviceViewModel, HeaderDevicesSimulatorViewModel headerDevicesSimulatorViewModel);
        IList<DeviceSimulatorModel> GetAllDeviceSimulator();
        DeviceSimulatorModel getSimDevicesByDeviceSimulatorId(int id);
        int SaveCreateSimDevices(ObservableCollection<SimDeviceViewModel> simDeviceViewModel, HeaderDevicesSimulatorViewModel headerDevicesSimulatorViewModel);
        int SaveChangeSimDevices(ObservableCollection<SimDeviceViewModel> simDeviceViewModel, HeaderDevicesSimulatorViewModel headerDevicesSimulatorViewModel);
        bool DeleteSimDevices(int deviceSimId, int simDeviceId);
    }
}
