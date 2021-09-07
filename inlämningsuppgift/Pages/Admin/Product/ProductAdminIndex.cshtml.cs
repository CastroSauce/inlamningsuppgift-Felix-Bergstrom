using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using inlämningsuppgift.Models;
using inlämningsuppgift.Services.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace inlämningsuppgift.Pages.Admin.Tour
{


    [Authorize(Roles = "Admin")]
    public class ProductAdminIndexModel : PageModel
    {
        private IProductService _productService { get; set; }

        public List<AdminProductViewModel> adminProducts { get; set; }

        [Required]
        [HiddenInput]
        [BindProperty]
        public int productToDeleteId { get; set; }

        public ProductAdminIndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public async Task OnGet(string? query)
        {
          adminProducts = await _productService.GetProductsAdminAsync(query);
        }

        public async Task<ActionResult> OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }

           await _productService.DeleteProductByIdAsync(productToDeleteId);

            return RedirectToPage("/Admin/Product/ProductAdminIndex");
        }
    }
}
