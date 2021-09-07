using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace inlämningsuppgift
{
   public enum Countries
    {
        [Display(Name = "Japan")]
        Japan,
        [Display(Name = "Sweden")]
        Sweden,
        [Display(Name = "Spain")]
        Spain,
        [Display(Name = "China")]
        China,
        [Display(Name = "Germany")]
        Germany,
        [Display(Name = "Italy")]
        Italy,
        [Display(Name = "Norway")]
        Norway,
        [Display(Name = "France")]
        France,
        [Display(Name = "Finland")]
        Finland
    }
}
