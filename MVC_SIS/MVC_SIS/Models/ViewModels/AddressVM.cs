using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Models.ViewModels
{
    public class AddressVM
    {
        public Student Student { get; set; }
        public Address Address { get; set; }
        //public List<SelectListItem> StateItems { get; set; }

        //public AddressVM()
        //{
        //    StateItems = new List<SelectListItem>();
        //}

        //public void SetStateItems(IEnumerable<State> states)
        //{
        //    foreach (var state in states)
        //    {
        //        StateItems.Add(new SelectListItem()
        //        {
        //            Value = state.StateAbbreviation,
        //            Text = state.StateName
        //        });
        //    }
        //}
    }

    
}