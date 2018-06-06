using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdWebAPI.Models.Tables
{
    public class Dvd
    {
        public int DvdID { get; set; }
        public string Title { get; set; }
        public int ReleaseID { get; set; }
        public int DirectorID { get; set; }
        public int RatingID { get; set; }
        public string Note { get; set; }
    }
}
