using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.ViewModels
{
    public class AddStudentVM
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "You must enter a 'first name'!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You must enter a 'last name'!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "You must enter a 'GPA'!")]
        public int GPA { get; set; }
        [Required(ErrorMessage = "You must enter an 'address'!")]
        public Address Address { get; set; }
        [Required(ErrorMessage = "You must choose a 'major'!")]
        public Major Major { get; set; }
        [Required(ErrorMessage = "You must choose at least one 'course'!")]
        public List<Course> Courses { get; set; }
    }
}