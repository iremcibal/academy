using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            List<MethodInterceptionBaseAttribute> classAttributes =
                type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            List<MethodInterceptionBaseAttribute> methodAttributes =
                type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true)
                    .ToList();
            classAttributes.AddRange(methodAttributes);

            return classAttributes.OrderBy(a => a.Priority).ToArray();
        }
    }
}
