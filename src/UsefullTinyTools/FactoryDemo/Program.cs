using FactoryDemo.Operators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDemo
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine("请输入第一个数字：");
            var numbera = Console.ReadLine();

            Console.WriteLine("请输入第二个数字：");
            var numberb = Console.ReadLine();

            Console.WriteLine("请输入操作符号：");
            var operattype = Console.ReadLine();

            var oper = OperatorFactory.CreateOperator(operattype);
            oper.NumberA = double.Parse(numbera);
            oper.NumberB = double.Parse(numberb);
            var result = oper.GetResult();

            Console.WriteLine($"{numbera}{operattype}{numberb}={result}");
            Console.ReadKey();
        }
    }
}
