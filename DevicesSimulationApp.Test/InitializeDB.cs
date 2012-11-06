using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeviceSimulation.Infrastructure;
using System.Data.Entity;


namespace DevicesSimulationApp.Test
{
    [TestClass]
    public class InitializeDB
    {
        //[TestInitialize]
        //public void InitializeDatabase()
        //{
        //    Database.SetInitializer<DSContext>(null);
        //        //new DeviceSimDropCreateDatabaseAlways());
        //}
        [TestMethod]
        public void TestMethod1()
        {
            using (DSContext context = new DSContext())
            {
                context.Database.Initialize(true);

            }
        }
    }
}
