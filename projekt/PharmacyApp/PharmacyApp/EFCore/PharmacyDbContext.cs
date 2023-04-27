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
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ChristianKu\Desktop\OopProjekt\oop\projekt\PharmacyApp\PharmacyApp\DrugDatabase.mdf;Integrated Security=True");

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
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.Price).IsRequired();
            });
        }
    }
}
