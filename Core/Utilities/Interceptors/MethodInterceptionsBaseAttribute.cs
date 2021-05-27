using Castle.DynamicProxy;
using System;
namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,Inherited = true,AllowMultiple = true)]
    public abstract class MethodInterceptionsBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {
        }
    }
}
