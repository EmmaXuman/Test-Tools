using FactoryDemo.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDemo
{
    public class OperatorFactory
    {
        public static BaseOpterator CreateOperator(string opterateType)
        {
            BaseOpterator opterator = null;
            switch (opterateType)
            {
                case "+":
                    opterator = new AddOperator();
                    break;
                case "-":
                    opterator = new SubtractOperator();
                    break;
                case "*":
                    opterator = new MultiplyOperator();
                    break;
                case "/":
                    opterator = new EliminateOperator();
                    break;
            }
            return opterator;
        }
    }
}
