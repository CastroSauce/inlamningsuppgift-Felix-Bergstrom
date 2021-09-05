using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inlämningsuppgift.Models
{
    public class Catagory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool onHomepage { get; set; } = false;
        public image image { get; set; }

    }
}
