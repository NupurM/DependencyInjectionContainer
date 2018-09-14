using System;
using DependencyInjectionContainer.A;
using DependencyInjectionContainer.B;
using DependencyInjectionContainer.Container;

namespace DependencyInjectionContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate container
            DiContainer container = new DiContainer();

            // Register classes to container
            container.Register<IInterfaceA, ClassA>();
            container.Register<IInterfaceB, ClassB>();

            // Resolve class from container
            IInterfaceB classB = container.Resolve<IInterfaceB>();
            classB.DoB();

            Console.ReadKey();
        }
    }
}
