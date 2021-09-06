using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inlämningsuppgift.Models;
using inlämningsuppgift.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace inlämningsuppgift.Pages.TourPage
{
    public class TourModel : PageModel
    {

        private IProductService _productService { get; set; }

        public List<ProductViewModel> products{ get; set; }

        public TourModel(IProductService productService)
        {
            _productService = productService;
        }


        public async Task OnGet(int? catagoryId, string? query)
        {
            products = await _productService.GetSpecificProductsAsync(catagoryId, query);

        }
    }
}
