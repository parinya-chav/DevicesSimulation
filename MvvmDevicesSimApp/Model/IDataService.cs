using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmDevicesSimApp.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
        void GetDevices(Action<DataItem, Exception> callback);
    }
}
