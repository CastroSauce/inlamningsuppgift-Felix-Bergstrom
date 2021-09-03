using inlämningsuppgift.Models;
using inlämningsuppgift.Services.Catagory;
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




    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IProductService _ProductService { get; set; }
        private ICatagoryService _CatagoryService { get; set; }





        public List<ProductViewModel> productList { get; set; }
        public List<CatagoryViewModel> catagoryList { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IProductService ProductService, ICatagoryService CatagoryService)
        {  
            _logger = logger;
            _ProductService = ProductService;
            _CatagoryService = CatagoryService;
        }

        public async Task OnGet()
        {
            productList = await _ProductService.GetAllProductsAsync();

            catagoryList = await _CatagoryService.GetAllCatagoriesAsync();
        }




    }
}
