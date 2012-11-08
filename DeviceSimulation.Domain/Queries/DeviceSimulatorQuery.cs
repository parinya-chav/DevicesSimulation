using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviceSimulation.Domain.Queries
{
    public static class DeviceSimulatorQuery
    {
        public static IQueryable<DeviceSimulator> GetAll(this IQueryable<DeviceSimulator> q)
        {
            return from ds in q select ds;
        }

        public static IQueryable<DeviceSimulator> GetById(this IQueryable<DeviceSimulator> q, int id)
        {
            return from ds in q where ds.Id == id select ds;
        }
    }
}
