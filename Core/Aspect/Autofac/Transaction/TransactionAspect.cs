using System;
using System.Transactions;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Core.Aspect.Autofac.Transaction
{
    public class TransactionAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (Exception)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
