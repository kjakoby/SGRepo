﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class Model
    {
        public int ModelID { get; set; }
        public int MakeID { get; set; }
        public string ModelName { get; set; }
        public DateTime ModelDateAdded { get; set; }
        public string UserID { get; set; }
    }
}
