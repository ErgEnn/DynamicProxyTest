using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.DynamicProxy;

namespace ProxyTest
{
    public class FooBar : IInterceptor
    {
        Dictionary<string,Delegate> events = new Dictionary<string, Delegate>();
        public T GetImplementation<T>() where T:class
        {
            return (new ProxyGenerator()).CreateInterfaceProxyWithoutTarget<T>(this);
        }

        public void Intercept(IInvocation invocation)
        {
            Debugger.Break();
            EventInfo eventInfo = invocation.Method.DeclaringType.GetEvents()
                .FirstOrDefault(info => info.AddMethod.Name == invocation.Method.Name);
            if (eventInfo != null)
            {
                events.Add(eventInfo.Name,invocation.Arguments[0] as Delegate);
            }

            if (invocation.Method.Name == "PrintText")
            {
                events["PrintThis"].DynamicInvoke(null, invocation.Arguments[0]);
            }
        }
    }
}
