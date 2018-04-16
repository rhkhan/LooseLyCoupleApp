using System.ComponentModel.DataAnnotations;
using LooselyCouple.Model.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooseLyCoupleApp.ViewModels
{
    public class AspRolesFormViewModel:IValidatableObject
    {
        public string Name { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new RoleValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}