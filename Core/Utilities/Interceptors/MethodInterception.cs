using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, Exception exception) { }

    
        public override void Intercept(IInvocation invocation) // method
        {
            bool isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed(); // Method çalıştırılıyor.
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess) OnSuccess(invocation);
            }
            OnAfter(invocation);
        }
    }
}
