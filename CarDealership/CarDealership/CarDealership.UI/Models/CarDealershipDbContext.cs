using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class CarDealershipDbContext : IdentityDbContext<AppUser>
    {
        public CarDealershipDbContext() : base("GuildCars")
        {

        }
    }
}