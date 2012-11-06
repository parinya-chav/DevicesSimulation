using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using DevicesSimulation.Services;
using DeviceSimulation.Domain;

namespace DevicesSimulationApp.Test
{
    [TestClass]
    public class SQLiteServices
    {
        IDeviceSimService _deviceSimService;

        [TestMethod]
        public void TestMethod1()
        {
            _deviceSimService = new DeviceSimService();
            
            SimDoc simDoc = new SimDoc();
            simDoc.Description = "XXXXXXXXX";

            List<SimDevice> simList = new List<SimDevice>();
            simList.Add(new SimDevice
            {
                Imei = "111-111-111"
            });

            var ret = _deviceSimService.SaveSimDocs(simDoc, simList);
            Console.WriteLine("Result: {0}", ret.ToString());
        }
    }
}
