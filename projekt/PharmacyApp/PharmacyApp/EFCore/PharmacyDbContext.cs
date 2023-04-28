using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.EFCore
{
    public class PharmacyDbContext : DbContext
    {
        public DbSet<Drugs> drugs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\marek\Documents\C# projects\oop\projekt\PharmacyApp\PharmacyApp\DrugDatabase.mdf; Connect Timeout=30");

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drugs>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Brand).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Manufacturer).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Quantity).IsRequired().HasDefaultValue(0);
                entity.Property(e => e.Price).IsRequired().HasDefaultValue(0).HasColumnType("decimal(18,2)");
            });
        }

        public Drugs[] getAllDrugs(PharmacyDbContext context)
        {
            return context.drugs.ToArray();
        }

        public void addDrug(PharmacyDbContext context, int id, string name, string brand, string manufacturer, decimal price, int quantity)
        {
            if (!context.drugs.Any(s => s.Id == id))
            {
                context.drugs.Add(new Drugs() { Id = id, Name = name, Brand = brand, Manufacturer = manufacturer, Price = price, Quantity = quantity});
            }
        }

        public void editDrug(PharmacyDbContext context, int id, string name, string brand, string manufacturer, decimal price, int quantity)
        {
            var drug = context.drugs.Find(id);
            if (drug != null)
            {
                drug.Name = name;
                drug.Brand = brand;
                drug.Manufacturer = manufacturer;
                drug.Price = price;
                drug.Quantity = quantity;

                context.drugs.Update(drug);
                context.SaveChanges();
            }
        }
    }
}
