using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public class AspectInterCeptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttribute = type.GetCustomAttributes<MethodInterceptionsBaseAttribute>
                (true).ToList();
            var methodAttributes =
                type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionsBaseAttribute>(true);
            classAttribute.AddRange(methodAttributes);
            return classAttribute.OrderBy(x => x.Priority).ToArray();
        }
    }
}
