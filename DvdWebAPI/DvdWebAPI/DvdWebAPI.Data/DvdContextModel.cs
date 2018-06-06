using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdWebAPI.Data
{
    public partial class DvdContextModel : DbContext
    {
        public DvdContextModel()
            : base("name=DvdContextModel")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
    }
}
