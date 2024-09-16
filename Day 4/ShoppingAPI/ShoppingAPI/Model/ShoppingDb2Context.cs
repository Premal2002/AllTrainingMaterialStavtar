using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShoppingAPI.Model;

public partial class ShoppingDb2Context : DbContext
{
    public ShoppingDb2Context()
    {
    }

    public ShoppingDb2Context(DbContextOptions<ShoppingDb2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }//maps to th table

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=PREMAL\\SQLEXPRESS;database=shoppingDB_2;integrated security=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__products__2D10D16A609080EE");

            entity.ToTable("products");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("productId");
            entity.Property(e => e.ProductCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("productCategory");
            entity.Property(e => e.ProductIsInStock).HasColumnName("productIsInStock");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("productName");
            entity.Property(e => e.ProductPrice).HasColumnName("productPrice");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
