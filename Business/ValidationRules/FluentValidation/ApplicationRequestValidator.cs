using Business.Requests.Applications;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ApplicationRequestValidator : AbstractValidator<CreateApplicationRequest>
    {
        public ApplicationRequestValidator()
        {
            RuleFor(a=>a.BootcampId).NotEmpty();
            RuleFor(a=>a.ApplicantId).NotEmpty();
            RuleFor(a=>a.StateId).NotEmpty();
        }
    }
}
