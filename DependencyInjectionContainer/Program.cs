using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionContainer.A;
using DependencyInjectionContainer.B;
using DependencyInjectionContainer.Container;

namespace DependencyInjectionContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            DiContainer container = new DiContainer();
            container.Register<IInterfaceA, ClassA>();
            container.Register<IInterfaceB, ClassB>();

            Console.ReadKey();
        }
    }
}
