using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises
{
    public class CantBeBlankStringAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string)
            {
                string checkfield = (string)value;
                if (string.IsNullOrEmpty(checkfield))
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}