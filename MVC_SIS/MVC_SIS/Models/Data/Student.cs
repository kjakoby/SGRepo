using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Student : IValidatableObject
    {
        public int StudentId { get; set; }
        //[Required(ErrorMessage = "You must enter a first name!")]
        public string FirstName { get; set; }
        //[Required(ErrorMessage = "You must enter a last name!")]
        public string LastName { get; set; }
        //[Required(ErrorMessage = "You must enter a GPA!")]
        public decimal GPA { get; set; }
        public List<Address> Address { get; set; }
        //[Required(ErrorMessage = "You must choose a major!")]
        public Major Major { get; set; }
        //[Required(ErrorMessage = "You must choose at least one course!")]
        public List<Course> Courses { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(FirstName))
            {
                errors.Add(new ValidationResult("The First Name field is required.", new[] { "FirstName" }));
            }
            if (string.IsNullOrEmpty(LastName))
            {
                errors.Add(new ValidationResult("The Last Name field is required.", new[] { "LastName" }));
            }
            if (string.IsNullOrEmpty(GPA.ToString()) || GPA>5||GPA<0)
            {
                errors.Add(new ValidationResult("You must enter a GPA between 0 and 5.", new[] { "GPA" }));
            }
            if (string.IsNullOrEmpty(Major.ToString()))
            {
                errors.Add(new ValidationResult("The Major field is required.", new[] { "Major" }));
            }

            return errors;
        }
    }
}