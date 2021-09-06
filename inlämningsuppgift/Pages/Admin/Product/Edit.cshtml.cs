using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace inlämningsuppgift.Pages.Admin.Product
{
        [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        public void OnGet()
        {





        }
    }
}
