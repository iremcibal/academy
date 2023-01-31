using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects
{
    public class TransactionAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
