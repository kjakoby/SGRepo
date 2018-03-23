using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipCalculator.Models
{
    public class TipCalculation
    {
        public decimal Total { get; set; }
        //public decimal PersonalPercent { get; set; }
        public decimal TenPercent { get; set; }
        public decimal FifteenPercent { get; set; }
        public decimal TwentyPercent { get; set; }
    }
}