using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inlämningsuppgift.Models;
using inlämningsuppgift.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace inlämningsuppgift.Pages.ProductPage
{
    public class ProductsDetailsModel : PageModel
    {
        [BindProperty]
        private IProductService _productService { get; set; }

        public ProductViewModel product{ get; set; }



        public ProductsDetailsModel(IProductService productService)
        {
            _productService = productService;
        }
        public async Task OnGet(int id)
        {
   

            product = await _productService.GetProductViewById(id);

           
        }


    }
}
