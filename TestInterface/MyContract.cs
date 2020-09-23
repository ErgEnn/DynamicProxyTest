using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestInterface
{
    public interface MyContract
    {
        Task DoThing();

        Task PrintText(string text);

        Task<Foo> GetFoo();

        Task<IEnumerable<Bar>> GetBars();

        event EventHandler<Foo> FooUpdated;

        event EventHandler<string> PrintThis;
    }

    public class Bar
    {
        public string S { get; set; }
    }

    public class Foo
    {
        public Foo(int i)
        {
            I = i;
        }
        public int I { get; }
    }
}
