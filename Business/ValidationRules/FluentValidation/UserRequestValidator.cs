using Business.Constants;
using Business.Requests.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public UserRequestValidator() {
            RuleFor(r=>r.FirstName).MinimumLength(2).NotEmpty().WithMessage(Messages.MustContainAtMinTwoChar);
            RuleFor(r=>r.LastName).MinimumLength(2).NotEmpty().WithMessage(Messages.MustContainAtMinTwoChar);
            RuleFor(r=>r.Email).NotEmpty().EmailAddress();
            RuleFor(r=>r.Password).MinimumLength(2).MaximumLength(10).NotEmpty().WithMessage(Messages.MustContainAtMinTwoChar).WithMessage(Messages.MustContainAtMaxTenChar);
            RuleFor(r=>r.NationalIdentity).Length(11).NotEmpty().WithMessage(Messages.PleaseEnterAValidNationalyIdNumber);
            RuleFor(r=>r.DateOfBirth).NotEmpty();
        
        }
    }
}
