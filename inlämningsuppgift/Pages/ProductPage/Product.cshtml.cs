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
using Microsoft.AspNetCore.Mvc.ViewFeatures;

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

        public int numOfPages { get; set; }

        public TourModel(IProductService productService)
        {
            _productService = productService;
        }



        public async Task<PartialViewResult> OnGetProductList(int pagenum, string? query, priceOrder order, int? catagoryId)
        {

            var prod = await _productService.GetSpecificProductsAsync(catagoryId, query, order, pagenum);

            return new PartialViewResult
            {
                ViewName = "../Shared/_MultipleProductPartial",
                ViewData = new ViewDataDictionary<List<ProductViewModel>>(ViewData, prod.products)
            };
        }

        public async Task OnGet(int? catagoryId, string? query, priceOrder order)
        {

            priceOrderList = htmlHelperFunctions.GenerateSelectList(enumHelper.GetpriceOrderStringList(),false);

            var page = await _productService.GetSpecificProductsAsync(catagoryId, query, order);

            products = page.products;

            numOfPages =  (int)Math.Round((decimal)(page.possibleResults / 3));
        }
    }
}
