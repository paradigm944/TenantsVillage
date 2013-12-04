namespace TV.web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<TV.web.Models.TVContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TV.web.Models.TVContext context)
        {
            
                WebSecurity.InitializeDatabaseConnection(
                    "DefaultConnection",
                    "UserProfile",
                    "UserId",
                    "UserName", autoCreateTables: true);

                if (!Roles.RoleExists("Administrator"))
                    Roles.CreateRole("Administrator");

                if (!WebSecurity.UserExists("seedAdmin"))
                    WebSecurity.CreateUserAndAccount(
                        "seedAdmin",
                        "password");

                var user = context.UserProfiles.Where(u => u.UserName == "seedAdmin").SingleOrDefault();
                user.Email = "paradigm944@gmail.com";
                user.isVerified = true;

                if (!Roles.GetRolesForUser("seedAdmin").Contains("Administrator"))
                    Roles.AddUsersToRoles(new[] { "seedAdmin" }, new[] { "Administrator" });
            
        }
    }
}
