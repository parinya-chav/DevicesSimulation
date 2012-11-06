using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevicesSimulationApp.Models;

namespace DevicesSimulationApp.Services
{
    public class ManageDevices
    {
        public DeviceSimulatorModel GenerateDevicesSim(AddDevicesSimModel addDevicesSim)
        {
            var deviceSims = new DeviceSimulatorModel();
            deviceSims.SimDeviceModel = new List<SimDeviceModel>();

            if (addDevicesSim.Qty > 0)
            {
                int i;
                for (i = 0; i < addDevicesSim.Qty; i++)
                {
                    var deviceSim = new SimDeviceModel();
                    deviceSim.PackageModel = new List<PackageModel>();

                    deviceSim.Imei = "SIM" + Convert.ToString(i + 1).PadLeft(4,'0');
                    deviceSim.SendTime = addDevicesSim.SendTime;

                    deviceSim.SendComplete = 0;
                    deviceSim.SendTotal = addDevicesSim.QtyXml;                                      

                    int j;
                    for (j = 0; j < addDevicesSim.QtyXml; j++)
                    {
                        var packageModel = new PackageModel
                        {
                            Sequence = j + 1,
                            Status = 0,
                            MessageType = ""
                        };
                        deviceSim.PackageModel.Add(packageModel);
                    }
                    
                    deviceSims.SimDeviceModel.Add(deviceSim);
                }
            }
            return deviceSims;
        }

        public List<StatusModel> GetStatusMaster()
        {
            var statusViewModels = new List<StatusModel>();

            statusViewModels.Add(new StatusModel
            {
                StatusID = 0,
                Description = "Inactive"
            });

            statusViewModels.Add(new StatusModel
            {
                StatusID = 1,
                Description = "Active"
            });

            return statusViewModels;
        }

        public List<SimDeviceModel> SendDevicesSimlute(List<SimDeviceModel> deviceSims)
        {
            try
            {
                foreach (var item in deviceSims)
                {
                    item.Status = 1;
                }
                return deviceSims;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }           
        }

        public string TestStartDevicesSimlute()
        {

            return "Sending...";
        }
    }
}
