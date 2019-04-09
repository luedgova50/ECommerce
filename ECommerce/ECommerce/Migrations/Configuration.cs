namespace WebECommerce.Migrations
{
    using System.Data.Entity.Migrations;
    using WebECommerce.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebECommerceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ECommerce.Models.WebECommerceContext";
        }

        protected override void Seed(WebECommerceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
