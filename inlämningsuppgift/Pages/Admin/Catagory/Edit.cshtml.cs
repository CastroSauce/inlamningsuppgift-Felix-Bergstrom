using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using inlämningsuppgift.Services.Catagory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static inlämningsuppgift.Pages.Admin.Catagory.CatagoryAdminIndexModel;

namespace inlämningsuppgift.Pages.Admin.Catagory
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        [BindProperty]
        public CatagoryDataModel catagory { get; set; }

        private ICatagoryService _catagoryService { get; set; }

        public EditModel(ICatagoryService catagoryService)
        {
            _catagoryService = catagoryService;
        }

        public async Task OnGet(int id)
        {
            catagory = await _catagoryService.GetById(id);
        }

        public async Task<ActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid) { return Page(); }

            await _catagoryService.UpdateCatagory(catagory);

            return RedirectToPage("/Admin/Catagory/CatagoryAdminIndex");
        }

    }
}
