using Microsoft.EntityFrameworkCore;
using InventoryManagementSystemMe.Models;


namespace InventoryManagementSystemMe.Data
{
    public class InventoryManagementContext : DbContext
    {
        public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options) : base(options) { }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchase { get; set; }

    }
}
