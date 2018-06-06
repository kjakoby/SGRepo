using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartupAttribute(typeof(CarDealership.UI.Startup))]
namespace CarDealership.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }


        // In this method we will create default User roles and Admin user for login   
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //create admin role and default admin user
            if (!roleManager.RoleExists("Admin"))
            {
                //create admin role
                var adminRole = new IdentityRole();
                adminRole.Name = "Admin";
                roleManager.Create(adminRole);

                //create super admin user
                var user = new ApplicationUser();
                user.UserName = "SuperAdmin";
                user.Email = "allmightyadmin@master.com";

                string superPassword = "SA_b4_SM";
                var checkUser = UserManager.Create(user, superPassword);

                //add super user to Admin role
                if (checkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            //create sales role and default sales user
            if (!roleManager.RoleExists("Sales"))
            {
                //create sales role
                var salesRole = new IdentityRole();
                salesRole.Name = "Sales";
                roleManager.Create(salesRole);

                //create super admin user
                var user = new ApplicationUser();
                user.UserName = "SuperSales";
                user.Email = "allmightysales@master.com";

                string superPassword = "SS_b4_SM";
                var checkUser = UserManager.Create(user, superPassword);

                //add super user to Admin role
                if (checkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Sales");
                }
            }
        }
    }
}