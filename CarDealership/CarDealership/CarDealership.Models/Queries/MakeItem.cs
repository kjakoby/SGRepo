using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class MakeItem
    {
        public int MakeID { get; set; }
        public string UserID { get; set; }
        public string MakeName { get; set; }
        public DateTime MakeDateAdded { get; set; }
        public string Email { get; set; }
    }
}
