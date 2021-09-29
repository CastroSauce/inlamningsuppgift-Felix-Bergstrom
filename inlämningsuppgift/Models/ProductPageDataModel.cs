using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inlämningsuppgift.Models
{
    public class ProductPageDataModel
    {
        public List<ProductViewModel> products { get; set; }
        public int possibleResults { get; set; }


    }
}
