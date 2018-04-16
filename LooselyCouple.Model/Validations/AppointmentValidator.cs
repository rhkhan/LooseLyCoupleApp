using FluentValidation;
using LooselyCouple.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Model.Validations
{
    public class AppointmentValidator: AbstractValidator<Appointment>
    {
        public AppointmentValidator()
        {
            RuleFor(r => r.PatientName).Length(3, 10)
                .WithMessage("Name must be 3 to 10 character length");
            RuleFor(r => r.PatientName).NotEmpty().WithMessage("Name cannot be empty");
        }

    }
}
