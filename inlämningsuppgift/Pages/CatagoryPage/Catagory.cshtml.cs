using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inlämningsuppgift.Models;
using inlämningsuppgift.Services.Catagory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace inlämningsuppgift.Pages.CatagoryPage
{


    public class CatagoryModel : PageModel
    {
    private ICatagoryService _catagoryService { get; set; }
        
    public List<CatagoryViewModel> catagories { get; set; }

        public CatagoryModel(ICatagoryService catagoryService)
        {
            _catagoryService = catagoryService;
        }
        
        public async Task OnGet()
        {
            catagories = await _catagoryService.GetAllCatagoriesAsync();

        }
    }
}
