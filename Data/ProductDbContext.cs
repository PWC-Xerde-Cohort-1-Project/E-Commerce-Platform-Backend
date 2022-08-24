using eCommerce.Model;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data
{
    public class ProductDbContext :DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base (options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
