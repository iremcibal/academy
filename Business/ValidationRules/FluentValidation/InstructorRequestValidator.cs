using Business.Requests.Instructors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class InstructorRequestValidator : AbstractValidator<CreateInstructorRequest>
    {
        public InstructorRequestValidator()
        {
            RuleFor(i=>i.CompanyName).NotEmpty();
        }
    }
}
