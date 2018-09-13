using System;

namespace DependencyInjectionContainer.A
{
    public class ClassA : IInterfaceA
    {
        public void DoA()
        {
            Console.WriteLine("Do A");
        }
    }
}