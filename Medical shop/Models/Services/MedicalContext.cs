using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Medical_shop.Models.Services
{
    public class MedicalContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<TypeOfProduct> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasMany(c => c.Products)
                .WithMany(s => s.Orders)
                .Map(t => t.MapLeftKey("OrderId")
                .MapRightKey("ProductId")
                .ToTable("OrderProduct"));
        }
    }
}