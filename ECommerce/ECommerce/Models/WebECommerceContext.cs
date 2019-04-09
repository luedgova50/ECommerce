namespace WebECommerce.Models
{
    using System.Collections;
    using System.Data.Entity;

    public class WebECommerceContext : DbContext
    {
        public WebECommerceContext() : base("DefaultConnection")
        {

        }

        public DbSet<State> State { get; set; }

        public DbSet<City> Cities { get; set; }
    }
}