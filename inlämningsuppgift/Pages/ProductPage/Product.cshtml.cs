using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inlämningsuppgift.enums;
using inlämningsuppgift.helpers;
using inlämningsuppgift.Models;
using inlämningsuppgift.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace inlämningsuppgift.Pages.TourPage
{
    public class TourModel : PageModel
    {


        private IProductService _productService { get; set; }

        [HiddenInput]
        public string? query { get; set; }

        public priceOrder? order { get; set; }

        public List<SelectListItem> priceOrderList { get; set; }

        public List<ProductViewModel> products{ get; set; }

        public TourModel(IProductService productService)
        {
            _productService = productService;
        }


        public async Task OnGet(int? catagoryId, string? query, priceOrder order)
        {

            priceOrderList = htmlHelperFunctions.GenerateSelectList(enumHelper.GetpriceOrderStringList(),false);

            products = await _productService.GetSpecificProductsAsync(catagoryId, query, order);

        }
    }
}
