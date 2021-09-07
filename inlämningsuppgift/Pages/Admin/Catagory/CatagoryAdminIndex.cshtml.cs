using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using inlämningsuppgift.Models;
using inlämningsuppgift.Services.Catagory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace inlämningsuppgift.Pages.Admin.Catagory
{
    [Authorize(Roles = "Admin")]
    public class CatagoryAdminIndexModel : PageModel
    {
        private  ICatagoryService _catagoryService { get; set; }

        [BindProperty]
        [HiddenInput]
        public int catagoryToDeleteId { get; set; }


        public class CatagoryDataModel
        {

            [HiddenInput]
            public int id { get; set; }

            [Required]
            [MaxLength(20)]
            public string name { get; set; }

            public bool onHomepage { get; set; } = false;

            public image image{ get; set; }
        }

        [BindProperty]
        public List<CatagoryViewModel> catagory { get; set; }

        public CatagoryAdminIndexModel(ICatagoryService catagoryService)
        {
            _catagoryService = catagoryService;
        }

        public async Task OnGet()
        {
             catagory = await _catagoryService.GetAllCatagoriesAsync();
        }

        public async Task<ActionResult> OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }

            await _catagoryService.DeleteCatagory(catagoryToDeleteId);

            return RedirectToPage("/Admin/Catagory/CatagoryAdminIndex");
        }
    }
}
