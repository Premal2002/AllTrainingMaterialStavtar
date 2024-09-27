using Microsoft.EntityFrameworkCore;

namespace VendorManagementAPI.Models
{
    public class VendorManagementContext : DbContext
    {
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<InvoiceVendorCurrencyView> InvoiceVendorCurrencyViews { get; set; }

        public VendorManagementContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
              optionsBuilder.LogTo(log => File.AppendAllText("enforce.log", log + Environment.NewLine), LogLevel.Information);
        }

        //Optionally, override OnModelCreating if you want to customize mapping further
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API configuration (if needed)
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<InvoiceVendorCurrencyView>()
                .HasNoKey()
                .ToView("InvoiceVendorCurrencyView");
        }
    }
}
