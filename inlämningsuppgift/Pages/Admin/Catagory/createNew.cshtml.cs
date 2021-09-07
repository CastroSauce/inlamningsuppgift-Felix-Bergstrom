using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inlämningsuppgift.Services.Catagory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static inlämningsuppgift.Pages.Admin.Catagory.CatagoryAdminIndexModel;

namespace inlämningsuppgift.Pages.Admin.Catagory
{
    public class createNewModel : PageModel
    {
        private ICatagoryService _catagoryService { get; set; }

        [BindProperty]
        public CatagoryDataModel catagory{ get; set; }

        public createNewModel(ICatagoryService catagoryService)
        {
            _catagoryService = catagoryService;
        }

        public async Task OnGet()
        {

        }


        public async Task<ActionResult> OnPost()
        {
            if (!ModelState.IsValid){ return Page();}

            await _catagoryService.SaveNewCatagory(catagory);

            return RedirectToPage("/Admin/Product/ProductAdminIndex");
        }
    }
}
