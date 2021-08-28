using inlämningsuppgift.Models;
using inlämningsuppgift.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inlämningsuppgift.Pages
{

    public class ProductModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public string price { get; set; }
    }


    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IProductService _ProductService { get; set; }

        public List<ProductModel> productList { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IProductService ProductService)
        {
            _logger = logger;
            _ProductService = ProductService;
        }

        public async void OnGet()
        {
            var products = await _ProductService.GetAllProducts();


        }
    }
}
