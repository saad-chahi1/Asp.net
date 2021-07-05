namespace PROJET_1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PROJET_1.Models.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "PROJET_1.Models.Model1";
        }

        protected override void Seed(PROJET_1.Models.Model1 context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
