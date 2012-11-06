using System;
using MvvmDevicesSimApp.Model;

namespace MvvmDevicesSimApp.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            callback(item, null);
        }
        public void GetDevices(Action<DataItem, Exception> callback)
        {
            var item = new DataItem();
            callback(item, null);
        }
    }
}