using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Responses
{
    public class EditOrderResponse : Response
    {
        public Order Order { get; set; }
        public Tax StateTax { get; set; }
        public Product Product { get; set; }
        public int OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public string CustName { get; set; }
        public string StateAbbrev { get; set; }
        public decimal TaxRate { get; set; }
        public string ProductType { get; set; }
        public decimal Area { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal LaborCost { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
    }
}
