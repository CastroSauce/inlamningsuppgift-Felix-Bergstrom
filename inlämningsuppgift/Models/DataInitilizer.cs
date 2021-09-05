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
            seedImages(dbContext);
            seedCatagories(dbContext);
            seedProducts(dbContext);
        }

        private static void seedImages(ApplicationDbContext dbContext)
        {
            if(!dbContext.images.Any(x => x.url == "/images/default.png"))
            {
                dbContext.Add(new image { url = "/images/default.png", altText = "no image available" });
            }

            dbContext.SaveChanges();
        }


        private static void seedCatagories(ApplicationDbContext dbContext)
        {

            if(!dbContext.catagories.Any(x => x.Name == "Balloon flights"))
                dbContext.Add(new Catagory { onHomepage = true, Name = "Balloon flights" });

            if (!dbContext.catagories.Any(x => x.Name == "Train adventures"))
                dbContext.Add(new Catagory { onHomepage = true, Name = "Train adventures" });

            if (!dbContext.catagories.Any(x => x.Name == "Sailing trips"))
                dbContext.Add(new Catagory { onHomepage = true, Name = "Sailing trips" });

            if (!dbContext.catagories.Any(x => x.Name == "Biking experiences"))
                dbContext.Add(new Catagory { Name = "Biking experiences" });

            dbContext.SaveChanges();
        }



        private static void seedProducts(ApplicationDbContext dbContext)
        {
            var bycleTrip = dbContext.catagories.First(x => x.Name == "Biking experiences");
            var airtrip = dbContext.catagories.First(x => x.Name == "Balloon flights");
            var trainTrip = dbContext.catagories.First(x => x.Name == "Train adventures");
            var boattrip = dbContext.catagories.First(x => x.Name == "Sailing trips");


            if (!dbContext.products.Any(x => x.Name == "The Friendship Highway"))
                dbContext.Add(new Product { onHomepage = true, Name = "The Friendship Highway",location = Countries.China , catagory = bycleTrip, price = 2323, description = "Whether or not the 800 kilometers (500 miles) between the Tibetan city of Lhasa and the Nepalese border is the planet's most beautiful ride depends on your idea enjoyment of sometimes bleak high-altitude vistas. The route includes three road passes of more than 5,000 meters (16,400 feet), with a lung-bursting maximum of 5,220 meters over the Gyatso La mountain pass, where the reward on a clear day is a distant view of Everest." });

            if (!dbContext.products.Any(x => x.Name == "La Ruta de los Conquistadores"))
                dbContext.Add(new Product { onHomepage = true, Name = "La Ruta de los Conquistadores", location = Countries.Spain, catagory = bycleTrip, price = 53432, description = "From the Pacific to Caribbean coasts, this one takes in mud paths, rainforest, coffee plantations, even an extinct volcano. It can be completed in three days each November as part of the annual mountain bike race from which the ride takes its name. Those in less of a rush can spend as long as they like, whenever they like, tracing the route of the 16th-century Spanish conqueror Juan de Cavallon, the chief conquistador of the title. Costa Rica has a vast range of natural wonder packed into an area roughly the size of Switzerland, around a quarter of it national park -- La Ruta delivers a decent taste of this." });
            
            if (!dbContext.products.Any(x => x.Name == "North Sea Cycle Route"))
                dbContext.Add(new Product { onHomepage = true, Name = "North Sea Cycle Route", location = Countries.Sweden, catagory = bycleTrip, price = 9999, description = "The NSCR, which also goes by the slightly less evocative name of Euro Velo Route 12, is a Euroskeptic's nightmare -- an EU-funded epic across eight countries that claims to be the longest signposted cycle route in the world. Covering almost 6,000 kilometers (3,728 miles), it runs from the northern edge of Scotland's Shetland Islands along the coasts of Britain, France, Belgium, the Netherlands, Germany, Denmark, Sweden and Norway. " });
            
            if (!dbContext.products.Any(x => x.Name == "The Shimanami Kaido"))
                dbContext.Add(new Product { Name = "The Shimanami Kaido", location = Countries.Japan, catagory = bycleTrip, price = 123, description = "At a shade more than 64 kilometers (40 miles) this is perhaps the only route on this list on which riders could reasonably consider taking their kids the full length without worrying about a visit from social services. Completely separated from the road, it snakes across a series of small, wonderfully scenic islands in Hiroshima prefecture, in the west of the country. Japan might be more popularly associated with the car rather than the bike, but cycling is common here and the Shimanami Kaido shows how two and four wheels can happily coexist." });



            if (!dbContext.products.Any(x => x.Name == "The Flam Railway"))
                dbContext.Add(new Product { Name = "The Flam Railway",image = new image { url = "/images/shrek.jpg"} , location = Countries.France, catagory = trainTrip, price = 32213, description = "Feel like you're on top of the world - literally - at the start of the 310-mile railway running from Oslo to Bergen in Norway - the highest major train route in Northern Europe. The journey from the mountain station of Myrdal down to Flam deep in the fjord has been voted one of the most scenic rail journeys in the world, and is also one of the steepest normal track railway lines, dropping 2,824 feet to the fjord below in just under an hour. Take in the awe-inspiring views of rugged mountains, deep valleys, and thundering waterfalls as you descend into the Aurlandsfjord." });

            if (!dbContext.products.Any(x => x.Name == "Venice Simplon-Orient-Express"))
                dbContext.Add(new Product { Name = "Venice Simplon-Orient-Express", location = Countries.Italy, catagory = trainTrip, price = 6444, description = "The iconic Venice Simplon-Orient Express is synonymous with everything that is 'luxury rail travel,' including glamour and sophistication, impeccable service, and iconic journeys that hearken back to a different time when rail travel was the epitome of style and class. Experience pure comfort, opulent interiors, fine dining, and convivial company along the tracks as you relive the 'golden age of rail travel' on this unforgettable journey to/from London to Paris and/or Venice, Florence, Rome and Verona!" });

            if (!dbContext.products.Any(x => x.Name == "Rocky Mountaineer"))
                dbContext.Add(new Product { Name = "Rocky Mountaineer", location = Countries.Norway, catagory = trainTrip, price = 12353, description = "A journey aboard the famed navy blue and gold carriages of the Rocky Mountaineer has topped many a bucket list over the years. Synonymous with true luxury, breathtaking adventures, delicious food, inspiring landscapes, and unparalleled service – Canada’s Rocky Mountains await, and this is a truly spectacular way to experience them! The thrilling two-day journey covers four different routes through the Rockies to Banff, Jasper,  Lake Louise, Whistler, and Quesnel, over the old Canadian Pacific line to Vancouver, which created the modern nation of Canada in 1885. Experience glacier-fed lakes, lush forest, rushing rivers, and an abundance of wildlife right outside your window. If you book a “Gold Leaf” ticket, you will enjoy riding and dining in traditional-style Dome Cars for premium views and the utmost comfort." });

            if (!dbContext.products.Any(x => x.Name == "The Jacobite Steam Train"))
                dbContext.Add(new Product { Name = "The Jacobite Steam Train", location = Countries.France, catagory = trainTrip, price = 523, description = "Discover one of Britain’s best-loved scenic railways on this epic 42-mile journey, through the dramatic, wild expanses of the Scottish Western Highlands. Travel by steam train on the vintage carriages of The Jacobite, starting at the highest mountain in Britain, Ben Nevis, in Fort William. Marvel at the natural sights out your window as the train winds through mountain and glen, and over massive viaducts to Europe’s deepest seawater loch, Loch Morar, on the way to Mallaig. You'll also stop at the charming village of Glenfinnan and pass scenic beaches before the commencement of your journey. This scenic line has come to have a more recent popularity as the Hogwarts Express, as it was featured in the famous Harry Potter books and movies." });



            dbContext.SaveChanges();
        }
    }
}
