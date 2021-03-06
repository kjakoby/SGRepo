namespace CarDealership.UI.Migrations
{
    using CarDealership.UI.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    //internal sealed class Configuration : DbMigrationsConfiguration<CarDealership.UI.Models.CarDealershipDbContext>
    //{
    //    public Configuration()
    //    {
    //        AutomaticMigrationsEnabled = false;
    //    }

    //protected override void Seed(CarDealershipDbContext context)
    //{
    //    var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
    //    var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

    //    if (roleMgr.RoleExists("admin"))
    //    {
    //        return;
    //    }

    //    roleMgr.Create(new AppRole() { Name = "admin" });

    //    var user = new AppUser()
    //    {
    //        UserName = "Admin1"
    //    };

    //    userMgr.Create(user, "testing123");

    //    userMgr.AddToRole(user.Id, "admin");
    //    //  This method will be called after migrating to the latest version.

    //    //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
    //    //  to avoid creating duplicate seed data. E.g.
    //    //
    //    //    context.People.AddOrUpdate(
    //    //      p => p.FullName,
    //    //      new Person { FullName = "Andrew Peters" },
    //    //      new Person { FullName = "Brice Lambson" },
    //    //      new Person { FullName = "Rowan Miller" }
    //    //    );
    //    //
    //}
    //}

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
