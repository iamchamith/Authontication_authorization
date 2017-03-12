namespace Auth.DbAccess.Migrations
{
    using Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Auth.DbAccess.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Auth.DbAccess.AppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.Authorizations.AddOrUpdate(
            //  new Authorization { Roles = Bo.Utility.Enums.Roles.Admin, Id = 1, Tag = "admin" },
            //  new Authorization { Roles = Bo.Utility.Enums.Roles.User, Id = 2, Tag = "user" }
            //);
            //
        }
    }
}
