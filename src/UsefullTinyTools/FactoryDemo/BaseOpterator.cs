using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDemo
{
    public abstract class BaseOpterator
    {
        public double NumberA { get; set; }
        public double NumberB { get; set; }
        public string Realize { get; }
        public abstract double GetResult();

        public virtual double GetResult( int type )
        {
            return 0;
        }
    }
}
