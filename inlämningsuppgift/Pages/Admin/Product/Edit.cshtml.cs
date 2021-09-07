using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using inlämningsuppgift.helpers;
using inlämningsuppgift.Services.Catagory;
using inlämningsuppgift.Services.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using static inlämningsuppgift.Pages.Admin.Product.createNewModel;

namespace inlämningsuppgift.Pages.Admin.Product
{
        [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        [BindProperty]
        public productDataModel product { get; set; }
        private ICatagoryService _catagoryService { get; set; }
        private IProductService _productService { get; set; }

        public List<SelectListItem> catagoryNameList { get; set; }
        public List<SelectListItem> countryList { get; set; } = htmlHelperFunctions.GenerateSelectList(enumHelper.GetCountryStringList(),false);

        [Required]
        [BindProperty]
        public string catagoryName { get; set; }

        public EditModel(IProductService productService, ICatagoryService catagoryService)
        {
            _productService = productService;
            _catagoryService = catagoryService;
        }
        public async Task OnGet(int id)
        {
            catagoryNameList = await FetchCatagoryList();

            product = await _productService.GetProductById(id);

            catagoryName = product.catagory.Name;
        }

        public async Task<ActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                catagoryNameList = await FetchCatagoryList();
                return Page();
            }
            product.catagory = await _catagoryService.GetCatagoryByName(catagoryName);

            await _productService.UpdateProduct(product);

            return RedirectToPage("/Admin/Product/ProductAdminIndex");
        }

        private async Task<List<SelectListItem>> FetchCatagoryList()
        {
            return htmlHelperFunctions.GenerateSelectList(await _catagoryService.GetAllCatagoryNamesAsync(),true, "Choose a catagory");
        }
    }
}
