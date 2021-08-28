using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inlämningsuppgift.Models
{
    public class DataInitilizer
    {


        public static void seed(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();
            seedCatagories(dbContext);
            seedProducts(dbContext);
        }



        private static void seedCatagories(ApplicationDbContext dbContext)
        {

            if(!dbContext.catagories.Any(x => x.Name == "Flygresor"))
                dbContext.Add(new Catagory { Name = "Flygresor" });

            if (!dbContext.catagories.Any(x => x.Name == "Tågresor"))
                dbContext.Add(new Catagory { Name = "Tågresor" });

            if (!dbContext.catagories.Any(x => x.Name == "Båtresor"))
                dbContext.Add(new Catagory { Name = "Båtresor" });

            if (!dbContext.catagories.Any(x => x.Name == "Cykelresor"))
                dbContext.Add(new Catagory { Name = "Cykelresor" });

            dbContext.SaveChanges();
        }



        private static void seedProducts(ApplicationDbContext dbContext)
        {
            var bycleTrip = dbContext.catagories.First(x => x.Name == "Cykelresor");
            var airtrip = dbContext.catagories.First(x => x.Name == "Flygresor");
            var trainTrip = dbContext.catagories.First(x => x.Name == "Tågresor");


            if (!dbContext.products.Any(x => x.Name == "Sverige cykelresa"))
                dbContext.Add(new Product { Name = "Sverige cykelresa", catagory = bycleTrip, price = 2323 });

            if (!dbContext.products.Any(x => x.Name == "Finland tågresa"))
                dbContext.Add(new Product { Name = "Finland tågresa", catagory = trainTrip, price = 53432 });
            
            if (!dbContext.products.Any(x => x.Name == "Sverige flygresa"))
                dbContext.Add(new Product { Name = "Sverige flygresa", catagory = airtrip, price = 9999 });
            
            if (!dbContext.products.Any(x => x.Name == "Sverige tågresa"))
                dbContext.Add(new Product { Name = "Sverige tågresa", catagory = trainTrip, price = 123 });

            dbContext.SaveChanges();
        }
    }
}
