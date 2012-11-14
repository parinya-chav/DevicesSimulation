using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviceSimulation.Domain
{
   public abstract  class Domain
    {
        public virtual int Id { get; protected set; }
        public virtual string Description { get; set; }
        public virtual byte Status { get; set; }
    }
}
