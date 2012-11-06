using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DeviceSimulation.Domain;
using System.Transactions;
using DeviceSimulation.Infrastructure;

namespace DevicesSimulation.Services
{
    public class DeviceSimService : IDeviceSimService
    {
        public DSContext DSContext { get; private set; }

        public DeviceSimService()
        {
            DSContext = new DSContext();
        }

        public bool SaveSimDocs(IDeviceSimulator deviceSimulator)
        {
            bool result = false;

            try
            {
                DSContext.SimDocs.Add(deviceSimulator.SimDoc);
                foreach (var item in deviceSimulator.SimDevices)
                {
                    item.SimDoc = deviceSimulator.SimDoc;
                    DSContext.SimDevices.Add(item);
                }

                using (TransactionScope transaction = new TransactionScope())
                {
                    DSContext.SaveChanges();
                    result = true;

                    transaction.Complete();                    
                }
            }
            catch (Exception ex)
            {
                result = false;
                //throw ex;
            }

            return result;
        }
    }
}
