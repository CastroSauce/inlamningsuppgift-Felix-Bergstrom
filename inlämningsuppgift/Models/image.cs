using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace inlämningsuppgift.Models
{
    public class image
    {
        public int Id { get; set; }

        public string url { get; set; }

        [MaxLength(20)]
        public string altText { get; set; }
    }
}
