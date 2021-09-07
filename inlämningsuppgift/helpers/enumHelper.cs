using inlämningsuppgift.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inlämningsuppgift.helpers
{
    public class enumHelper
    {

        public static List<string> GetCountryStringList()
        {
            return Enum.GetNames(typeof(Countries)).ToList();
        }

        public static List<string> GetpriceOrderStringList()
        {
            return Enum.GetNames(typeof(priceOrder)).ToList();
        }


    }
}
