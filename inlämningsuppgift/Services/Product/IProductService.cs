using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inlämningsuppgift.Models;
namespace inlämningsuppgift.Services.Product
{
   public interface IProductService
    {
       abstract public Task<List<ProductViewModel>> GetAllProductsAsync();
       abstract public Task<List<ProductViewModel>> GetAllOnHomepageAsync();
       abstract public Task<List<ProductViewModel>> GetSpecificProductsAsync(int? id, string? query);


    }
}
