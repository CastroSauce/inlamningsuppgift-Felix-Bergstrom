using inlämningsuppgift.Services.image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inlämningsuppgift.Models
{
    public class Product
    {
  

        public int Id { get; set; }

        public string Name { get; set; }

        public float price { get; set; }

        public string description { get; set; }

        public image? image { get; set; }

        public bool onHomepage { get; set; } = false;

        public Catagory catagory{ get; set; }

        public Countries location { get; set; }



    }
}
