using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace loginPage_v1.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PageContext.Ctx>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(loginPage_v1.PageContext.Ctx context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
