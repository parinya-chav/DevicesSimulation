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


        public int SaveSimDocs(DeviceSimulator deviceSimulator)
        {
            int result = 0;
            try
            {
                _session.SaveOrUpdate(deviceSimulator);
                result = deviceSimulator.Id;
                
            }
            catch (Exception ex)
            {
                result = 0;
                //throw ex;
            }

            return result;
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
    }
}
