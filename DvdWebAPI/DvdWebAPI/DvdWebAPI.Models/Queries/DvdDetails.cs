using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdWebAPI.Models.Queries
{
    public class DvdDetails
    {
        public int DvdID { get; set; }
        public string Title { get; set; }
        public int ReleaseID { get; set; }
        public int DirectorID { get; set; }
        public int RatingID { get; set; }
        public string Note { get; set; }
        public int Year { get; set; }
        public string DirectorName { get; set; }
        public string RatingValue { get; set; }
    }
}
