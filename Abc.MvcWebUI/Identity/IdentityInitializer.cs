using Abc.MvcWebUI.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            if(!context.Roles.Any(i => i.Name == "admin"))
            {
                var store=new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name="admin",Description="admin rolü"};
                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole(){ Name = "user", Description = "user rolü" };
                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "mehmetakin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser(){ Name = "mehmet" , Surname="akın", UserName="mehmetakin", Email="mhmt7818@gmail.com"};
                manager.Create(user,"1234567");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }
            if (!context.Roles.Any(i => i.Name == "aliaytek"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() {Id="2", Name = "ali", Surname = "aytekin", UserName = "ali", Email = "deneme@gmail.com" };
                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "user");
            }

            base.Seed(context);
        }
    }
}