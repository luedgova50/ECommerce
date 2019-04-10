namespace WebECommerce.Models
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class WebECommerceContext : DbContext
    {
        public WebECommerceContext() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.
                Conventions.
                Remove<
                    OneToManyCascadeDeleteConvention>();
        }

        public DbSet<State> State { get; set; }

        public DbSet<City> Cities { get; set; }

        public System.Data.Entity.DbSet<WebECommerce.Models.Company> Companies { get; set; }
    }
}