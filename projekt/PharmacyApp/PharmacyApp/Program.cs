using PharmacyApp.EFCore;
using Microsoft.EntityFrameworkCore;

using (var context = new PharmacyDbContext())
    {
        context.Database.Migrate();
    }

