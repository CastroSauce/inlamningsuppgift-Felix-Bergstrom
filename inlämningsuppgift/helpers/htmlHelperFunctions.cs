using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inlämningsuppgift.helpers
{
    public class htmlHelperFunctions
    {

        public static List<SelectListItem> GenerateSelectList(List<string> options,bool addPlaceholder = true, string placeholder = "Choose an option")
        {
            var list = new List<SelectListItem>();

            if (addPlaceholder) 
            {
                list.Add(new SelectListItem { Disabled = true, Selected = true, Text = placeholder, Value = "" });
            }
        

            list.AddRange(options.Select(option => new SelectListItem { Text = option, Value = option }));

            return list;
        }


    }
}
