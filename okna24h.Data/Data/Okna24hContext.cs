using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using okna24h.Data.Data.CMS;
using okna24h.Data.Data.Orders;
using okna24h.Data.Data.Shop;
using okna24h.Data.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data
{
    public class Okna24hContext : IdentityDbContext<ApplicationUser>
    {
        public Okna24hContext(DbContextOptions<Okna24hContext> options)
            : base(options)
        {
        }
        public DbSet<Banner> Banners { get; set; } = default!;
        public DbSet<CmsText> CmsTexts { get; set; } = default!;
        public DbSet<Media> Media { get; set; } = default!;
        public DbSet<News> News { get; set; } = default!;
        public DbSet<Website> Websites { get; set; } = default!;
        public DbSet<Invoice> Invoices { get; set; } = default!;
        public DbSet<InvoiceItem> InvoiceItems { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderItem> OrderItems { get; set; } = default!;
        public DbSet<Payment> Payments { get; set; } = default!;
        public DbSet<PaymentMethod> PaymentMethods { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Return> Returns { get; set; } = default!;
        public DbSet<ReturnItem> ReturnItems { get; set; } = default!;
        public DbSet<Shipment> Shipments { get; set; } = default!;
        public DbSet<ShipmentItem> ShipmentItems { get; set; } = default!;
        public DbSet<Tax> Taxes { get; set; } = default!;
        public DbSet<Article> Articles { get; set; } = default!;
        public DbSet<Colour> Colours { get; set; } = default!;
        public DbSet<Glass> Glasses { get; set; } = default!;
        public DbSet<Material> Materials { get; set; } = default!;
        public DbSet<MaterialType> MaterialsTypes { get; set; } = default!;
        public DbSet<MaterialTypeColor> MaterialTypeColors { get; set; } = default!;
        public DbSet<OpenningSystem> OpenningSystems { get; set; } = default!;
        public DbSet<Profile> Profiles { get; set; } = default!;
        public DbSet<Roller> Rollers { get; set; } = default!;
        public DbSet<Sash> Sashes { get; set; } = default!;
        public DbSet<Shutter> Shutters { get; set; } = default!;
        public DbSet<Size> Sizes { get; set; } = default!;
        public DbSet<Sort> Sorts { get; set; } = default!;
        public DbSet<Typ> Typs { get; set; } = default!;
        public DbSet<Address> Addresses { get; set; } = default!;
        public DbSet<City> Cities { get; set; } = default!;
        public DbSet<Country> Countries { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Employee> Employees { get; set; } = default!;
        public DbSet<PostCode> PostCodes { get; set; } = default!;
        public DbSet<Region> Regions { get; set; } = default!;
        public DbSet<Supplier> Suppliers { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<InvoiceItem>()
                .HasOne(ii => ii.OrderItem)
                .WithOne(oi => oi.InvoiceItem)
                .HasForeignKey<InvoiceItem>(ii => ii.OrderItemId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ReturnItem>()
                .HasOne(ri => ri.OrderItem)
                .WithOne(oi => oi.ReturnItem)
                .HasForeignKey<ReturnItem>(ri => ri.OrderItemId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ShipmentItem>()
                .HasOne(si => si.OrderItem)
                .WithOne(oi => oi.ShipmentItem)
                .HasForeignKey<ShipmentItem>(si => si.OrderItemId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

