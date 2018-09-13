using DependencyInjectionContainer.A;
using System;

namespace DependencyInjectionContainer.B
{
    public class ClassB : IInterfaceB
    {
        private readonly IInterfaceA _classA;
        public ClassB(IInterfaceA classA)
        {
            _classA = classA;
        }
        public void DoB()
        {
            _classA.DoA();
            Console.WriteLine("Do B");
        }
    }
}