using DeviceSimulation.Domain;
using DeviceSimulation.Infrastructure;
using NHibernate;
using NHibernate.Linq;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using DeviceSimulation.Infrastructure.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;

using DeviceSimulation.Domain.Queries;

namespace DevicesSimulation.Services
{
    public class DeviceSimService : IDeviceSimService
    {
        ISession _session;
        public DeviceSimService(ISession session)
        {
            _session = session;
        }        

        public IList<DeviceSimulator> GetAllDeviceSimulator()
        {
            IList<DeviceSimulator> deviceSimulators = new List<DeviceSimulator>();

            var query = _session.Query<DeviceSimulator>().GetAll();
            deviceSimulators = query.ToList();

            return deviceSimulators;
        }

        public DeviceSimulator GetByIdDeviceSimulator(int id)
        {
            var deviceSimulator = new DeviceSimulator();

            var query = _session.Query<DeviceSimulator>().GetById(id);
            deviceSimulator = query.FirstOrDefault();

            return deviceSimulator;
        }

        public DeviceSimulator GetByIdDeviceSimulatorIncludeChild(int id)
        {
            var deviceSimulator = new DeviceSimulator();

            var query = from d in _session.Query<DeviceSimulator>()
                        where d.Id == id
                        select d;

            deviceSimulator = query.FirstOrDefault();

            return deviceSimulator;
        }


        public string SendPacket(SimDevice simDevice)
        {
            simDevice.Description = string.Format("Send>>> Data[{0}]", simDevice.SendComplete.ToString());
            
            return simDevice.Description;
        }

        public SimDevice GetByIdSimDevice(int id)
        {
            var query = _session.Query<SimDevice>().GetById(id);
            var simDevice = query.FirstOrDefault();
            return simDevice;
        }

        public IList<Packet> GetPacketsByIdSimDevice(int id)
        {
            var query = from p in _session.Query<Packet>()
                        where p.SimDevice.Id == id
                        select p;
            var packets = query.ToList();
            return packets;
        }     
    }
}
