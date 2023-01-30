using Business.Requests.Blacklists;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BlacklistRequestValidator : AbstractValidator<CreateBlacklistRequest>
    {
        public BlacklistRequestValidator()
        {
            RuleFor(b=>b.Reason).NotEmpty();
            RuleFor(b=>b.date).NotEmpty();
            RuleFor(b=>b.ApplicantId).NotEmpty();
        }
    }
}
