using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDemo.Operators
{
    public class SubtractOperator:BaseOpterator
    {
        public new string Realize => "-";
        public override double GetResult()
        {
            return NumberA-NumberB;
        }
    }
}
