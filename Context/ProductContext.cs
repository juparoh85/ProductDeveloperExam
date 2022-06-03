using System.Data.Entity;

namespace WebApplication1.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<Models.Product> Products { get; set; }
    }
}
