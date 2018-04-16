using LooselyCouple.Model.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LooselyCouple.Model.Models
{
    public class Appointment: IValidatableObject
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string Phone { get; set; }
        public string appType { get; set; }
        public string appID { get; set; }
        public string SI { get; set; }
        //public string appDate { get; set; }
        public DateTime appDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new AppointmentValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item=>new ValidationResult(item.ErrorMessage,new[] { item.PropertyName }));
        }
    }
}
