using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using DeviceSimulation.Infrastructure.Mappings;
using DeviceSimulation.Domain;
using NHibernate.Cfg;
using System.IO;
using NHibernate.Tool.hbm2ddl;

namespace DeviceSimulation.Infra.Test
{
    [TestClass]
    public class UnitTest1
    {
        private const string DbFile = "D:\\Lab\\LabSQLite\\firstProgram.db";

        [TestMethod]
        public void TestSimpleSave()
        {
            DeviceSimulator deviceSimulator = new DeviceSimulator();
            deviceSimulator.Description = "XXXXX";

            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    for (int i = 0; i < 10; i++)
                    {
                        deviceSimulator.AddSimDevice(new SimDevice
                        {
                            Imei = "SIM" + i.ToString("0###"),
                        });
                    }

                    foreach (var item in deviceSimulator.SimDevices)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            item.AddPacket(new Packet
                            {
                                Description = "Desc" + i.ToString("0###")
                            });
                        }
                    }                            

                    session.SaveOrUpdate(deviceSimulator);
                    transaction.Commit();
                }
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                .UsingFile(DbFile))
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<DeviceSimulatorMap>())
                    .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }
        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists(DbFile))
                File.Delete(DbFile);

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
                .Create(false, true);
        }
                
    }
}
