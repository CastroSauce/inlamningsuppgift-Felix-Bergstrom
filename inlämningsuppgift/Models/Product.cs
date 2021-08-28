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

        public decimal description { get; set; }

        public Catagory catagory{ get; set; }



    }
}
