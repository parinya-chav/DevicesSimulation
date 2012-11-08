using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using DevicesSimulation.Services;
using DeviceSimulation.Domain;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using DeviceSimulation.Infrastructure.Mappings;

namespace DeviceSimulation.Service.Test
{
    [TestClass]
    public class UnitTest1
    {
        IDeviceSimService deviceSimService;

        [TestMethod]
        public void GetAllDeviceSimulatorService()
        {
            ISessionFactory sessionFactory = CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                deviceSimService = new DeviceSimService(session);

                var list = deviceSimService.GetAllDeviceSimulator();

                foreach (var item in list)
                {
                    Console.WriteLine("ID: {0}, Description: {1}", item.Id, item.Description);
                }
            }
        }

        [TestMethod]
        public void GetByIdDeviceSimulatorService()
        {
             ISessionFactory sessionFactory = CreateSessionFactory();
             using (var session = sessionFactory.OpenSession())
             {
                 deviceSimService = new DeviceSimService(session);
                 var device = deviceSimService.GetByIdDeviceSimulator(1);

                 Console.WriteLine("ID: {0}, Description: {1}", device.Id, device.Description);
             }
        }

        [TestMethod]
        public void GetByIdDeviceSimulatorIncludeChild()
        {
             ISessionFactory sessionFactory = CreateSessionFactory();
             using (var session = sessionFactory.OpenSession())
             {
                 deviceSimService = new DeviceSimService(session);

                 var device = deviceSimService.GetByIdDeviceSimulatorIncludeChild(1);

                 Console.WriteLine("ID: {0}, Description: {1}", device.Id, device.Description);
             }
        }

        private const string DbFile = "D:\\Lab\\LabSQLite\\firstProgram.db";
        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                .UsingFile(DbFile))
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<DeviceSimulatorMap>())
                .BuildSessionFactory();
        }
    }
}
