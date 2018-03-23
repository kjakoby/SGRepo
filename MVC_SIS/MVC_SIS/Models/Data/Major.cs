using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Major
    {
        //[CantBeBlankString(ErrorMessage = "You must choose a major!")]
        [Required(ErrorMessage = "You must choose a major!")]
        public int MajorId { get; set; }
        //[Required(ErrorMessage = "The Major field is required.")]
        public string MajorName { get; set; }
    }
}