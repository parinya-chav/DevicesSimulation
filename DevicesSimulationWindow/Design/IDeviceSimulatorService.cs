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
        string SendPacket();
        bool SaveSimDevices(ObservableCollection<SimDeviceViewModel> simDeviceViewModel);
    }
}
