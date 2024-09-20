using Microsoft.EntityFrameworkCore;




namespace CodeFirstTest.Model
{
    public class VendorManagementContext : DbContext
    {
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public VendorManagementContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        // Optionally, override OnModelCreating if you want to customize mapping further
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API configuration (if needed)
            base.OnModelCreating(modelBuilder);
        }
    }
}
