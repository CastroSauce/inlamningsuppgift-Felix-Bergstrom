using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using inlämningsuppgift.helpers;
using inlämningsuppgift.Models;
using inlämningsuppgift.Services.Catagory;
using inlämningsuppgift.Services.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace inlämningsuppgift.Pages.Admin.Product
{

    [Authorize(Roles = "Admin")]
    public class createNewModel : PageModel
    {

        private ICatagoryService _catagoryService { get; set; }
        private IProductService _productService{ get; set; }
        public createNewModel(ICatagoryService catagoryService, IProductService productService)
        {
            _catagoryService = catagoryService;
            _productService = productService;
        }


        [BindProperties]
        public class productDataModel
        {

            [HiddenInput]
            [Required]
            public int id { get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            public float price { get; set; }

            [Required]
            [StringLength(700)]
            public string description { get; set; }

            public image? image { get; set; }

            public bool onHomepage { get; set; } = false;

            public Models.Catagory catagory { get; set; }

            [Required]
            public Countries location { get; set; }
        }

        [BindProperty]
        public productDataModel product { get; set; }
        public List<SelectListItem> catagoryNameList { get; set; }
        public List<SelectListItem> countryList { get; set; } = htmlHelperFunctions.GenerateSelectList(enumHelper.GetCountryStringList(),true, "Choose a country");

        [Required]
        [BindProperty]
        public string catagoryName { get; set; }


        public async Task OnGet()
        {
            catagoryNameList = await FetchCatagoryList();

        }

        public async Task<ActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                catagoryNameList = await FetchCatagoryList();
                return Page();
            }

            product.catagory = await _catagoryService.GetCatagoryByName(catagoryName);

            await _productService.SaveNewProduct(product);

            return RedirectToPage("/Admin/Product/ProductAdminIndex");
        }


        private async Task<List<SelectListItem>> FetchCatagoryList()
        {
           return  htmlHelperFunctions.GenerateSelectList(await _catagoryService.GetAllCatagoryNamesAsync(),true ,"Choose a catagory");
        }
    }
}
