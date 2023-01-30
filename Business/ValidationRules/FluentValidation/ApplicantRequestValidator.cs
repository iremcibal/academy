using Business.Requests.Applicants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ApplicantRequestValidator : AbstractValidator<CreateApplicantRequest>
    {
        public ApplicantRequestValidator()
        {
            RuleFor(a => a.About).NotEmpty();
        }
    }
}
