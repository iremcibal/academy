using Business.Requests.Bootcamps;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BootcampRequestValidator : AbstractValidator<CreateBootcampRequest>
    {
        public BootcampRequestValidator()
        {
            RuleFor(b=>b.Name).NotEmpty();
            RuleFor(b=>b.StartDate).NotEmpty();
            RuleFor(b=>b.EndDate).NotEmpty();
            RuleFor(b=>b.StateId).NotEmpty();
            RuleFor(b=>b.InstructorId).NotEmpty();
        }
    }
}
