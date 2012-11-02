using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevicesSimulationWindow.Model;
using System.Collections.ObjectModel;

namespace DevicesSimulationWindow.Design
{
    public class StubDeviceSimulator : IPreDeviceSimulator
    {
        public string Name
        {
            get
            {
                return "iBon";
            }
            set
            {
                throw new NotImplementedException();
            }
        }
                
        public void Start()
        {
            throw new NotImplementedException();
        }
                
        IList<DeviceSimulation.Domain.SimDevice> DeviceSimulation.Domain.IDeviceSimulator.SimDevices
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private static IList<PreSimDevice> _fakeList;
        static StubDeviceSimulator()
        {
            if (_fakeList == null)
            {
                _fakeList = new ObservableCollection<PreSimDevice>();
                string[] descs = { "James", "John", "Danny", "Michelle", "Tina", "Rachel", "Todd", "Elaine", "Tonya", "Derek", "Mike" };
                string[] imei = { "SIM001A", "SIM0002", "SIM0003", "SIM000X", "SIM00TT", "SIM00YU", "SIM0088", "SIM00PP", "SIM0078", "SIM00WW", "SIM00QW" };

                Random r2 = new Random();
                Random r = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int index = r.Next(0, 11);
                    PreSimDevice p = new PreSimDevice
                    {
                        Imei = imei[index],
                        Description = descs[index],
                        SendTotal = r2.Next(10, 90),
                    };
                    _fakeList.Add(p);
                }
            }
        }

        public IList<PreSimDevice> PreSimDevices
        {
            get
            {
                return _fakeList;
            }
            set
            {
                throw new NotImplementedException();
            }
        }


    }
}
