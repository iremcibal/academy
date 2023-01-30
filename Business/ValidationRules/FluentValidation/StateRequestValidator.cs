using Business.Requests.States;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class StateRequestValidator : AbstractValidator<CreateStateRequest>
    {
        public StateRequestValidator()
        {
            RuleFor(s=>s.Info).NotEmpty();
        }
    }
}
