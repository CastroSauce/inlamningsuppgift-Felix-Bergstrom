using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inlämningsuppgift.enums;
using inlämningsuppgift.Models;
using static inlämningsuppgift.Pages.Admin.Product.createNewModel;

namespace inlämningsuppgift.Services.Product
{
   public interface IProductService
    {
       abstract public Task<List<ProductViewModel>> GetAllProductsAsync();
       abstract public Task<List<ProductViewModel>> GetAllOnHomepageAsync();
       abstract public Task<List<ProductViewModel>> GetSpecificProductsAsync(int? catagoryId, string? query, priceOrder? priceOrder);
       abstract public Task<productDataModel> GetProductById(int id);
       abstract public Task<ProductViewModel> GetProductViewById(int id);
       abstract public Task<List<AdminProductViewModel>> GetProductsAdminAsync(string? query);
       abstract public Task SaveNewProduct(productDataModel product);
       abstract public Task UpdateProduct(productDataModel product);
       abstract public Task DeleteProductByIdAsync(int id);


    }
}
