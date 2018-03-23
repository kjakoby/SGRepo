using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class State : IValidatableObject
    {
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(StateName))
            {
                errors.Add(new ValidationResult("The State Name field is required.", new[] { "StateName" }));
            }

            if(string.IsNullOrEmpty(StateAbbreviation))
            {
                    errors.Add(new ValidationResult("The State Abbreviation field is required.", new[] { "StateAbbreviation" }));
            }
            else if (StateAbbreviation.Length > 2)
            {
                errors.Add(new ValidationResult("The State Abbreviation must be two letters.", new[] { "StateAbbreviation" }));
            }

            return errors;
        }
    }
}