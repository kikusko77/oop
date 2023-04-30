using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Globalization;
using System.IO;

namespace PharmacyApp.EFCore
{
    public class PharmacyDbContext : DbContext
    {
        public DbSet<Drugs> drugs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ChristianKu\Desktop\oop\projekt\PharmacyApp\DrugDatabase.mdf; Connect Timeout=30");

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



        private readonly MainWindow mainWindow;

        public PharmacyDbContext(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
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
                context.SaveChanges();
                mainWindow.LoadDataGrid();
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
                mainWindow.LoadDataGrid();
            }
        }
        public void ImportFromCsv(PharmacyDbContext context, string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var drugs = csv.GetRecords<Drugs>().ToList();
                foreach (var drug in drugs)
                {
                    if (!context.drugs.Any(s => s.Id == drug.Id))
                    {
                        context.drugs.Add(drug);
                    }
                }
                context.SaveChanges();
                mainWindow.LoadDataGrid();
            }
        }

        public void ExportToCsv(PharmacyDbContext context, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                var drugs = context.drugs.ToList();
                csv.WriteRecords(drugs);
            }
        }

    }
}
