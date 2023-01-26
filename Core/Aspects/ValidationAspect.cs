using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects
{
    public class ValidationAspect : MethodInterception
    {
        private readonly Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
                throw new ArgumentException("Wrong validator type.");

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            IValidator validator = (Activator.CreateInstance(_validatorType) as IValidator)!;
            Type typeToValidate = _validatorType.BaseType.GetGenericArguments()[0];

            IEnumerable<object> argumentsToValidate = invocation.Arguments.Where(o => o.GetType() == typeToValidate);


            foreach (object argumentToValidate in argumentsToValidate)
            {
                ValidationTool.Validate(validator, argumentToValidate);
            }
        }
    }
}
