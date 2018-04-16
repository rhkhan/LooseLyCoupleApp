using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LooselyCouple.Model.Models;
using LooseLyCoupleApp.ViewModels;

namespace LooselyCouple.Model.Validations
{
    public class RoleValidator : AbstractValidator<AspRolesFormViewModel>
    {
        public RoleValidator() {
            RuleFor(r => r.Name).Length(3, 10)
                .WithMessage("Role must be 3 to 10 character length");
            RuleFor(r => r.Name).NotEmpty().WithMessage("Role name cannot be empty");
            RuleFor(r => r.Name).Must(hasNoDigits).WithMessage("Role name cannot contain any digit");
        }

        private bool hasNoDigits(string rolename)
        {
            if (!string.IsNullOrEmpty(rolename))
                return (!rolename.Any(char.IsDigit));
            else return true;

        }
    }
}
