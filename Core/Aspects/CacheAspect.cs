using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects
{
    public class CacheAspect : MethodInterception
    {
        private readonly int _duration;
        private readonly ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>()!;
        }
        public override void Intercept(IInvocation invocation)
        {
            string methodName = $"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}";
            List<object> methodArguments = invocation.Arguments.ToList();
            string cacheKey = $"{methodName}({methodArguments.Select(ma => ma.ToString() ?? "<Null>")})";

            if (_cacheManager.IsAdd(cacheKey))
            {
                invocation.ReturnValue = _cacheManager.Get(cacheKey);
                return;
            }

            invocation.Proceed();
            _cacheManager.Add(cacheKey, invocation.ReturnValue, _duration);
        }
    }
}
