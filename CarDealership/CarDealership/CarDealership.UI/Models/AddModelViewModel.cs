using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class AddModelViewModel
    {
        public Model Model { get; set; }
        public IEnumerable<SelectListItem> Makes { get; set; }
        public List<Model> ModelList { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Model.ModelName))
            {
                errors.Add(new ValidationResult("Model Name is required!"));
            }
            //if (string.IsNullOrEmpty(Makes))
            //{

            //}

            return errors;
        }
    }
}