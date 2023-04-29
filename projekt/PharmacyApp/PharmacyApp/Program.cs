using PharmacyApp.EFCore;
using Microsoft.EntityFrameworkCore;

using (var context = new PharmacyDbContext())
    {
        context.Database.Migrate();
    var Drugs = new Drugs
    {
        Name = "Aspirin",
        Brand = "Znacka",
        Manufacturer = "Bayer",
        Price = 9.99m,
        Quantity = 100
    };

    context.drugs.Add(Drugs);
    context.SaveChanges();


}

