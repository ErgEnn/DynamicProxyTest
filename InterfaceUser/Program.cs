using System;
using System.Diagnostics.Contracts;
using ProxyTest;
using TestInterface;

namespace InterfaceUser
{
    class Program
    {
        static void Main(string[] args)
        {
            FooBar fooBar = new FooBar();
            MyContract contract = fooBar.GetImplementation<MyContract>();
            contract.PrintThis += (sender, s) => Console.WriteLine($"Print this: {s}");
            contract.PrintText("Peeter");
        }
    }
}
