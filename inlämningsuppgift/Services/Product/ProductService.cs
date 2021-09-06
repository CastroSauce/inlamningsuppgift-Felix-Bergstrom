using inlämningsuppgift.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inlämningsuppgift.Services.Product
{
    public class ProductService : IProductService
    {
        private ApplicationDbContext _dbContext { get; }

        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<ProductViewModel>> GetAllProductsAsync()
        {
            return await _dbContext.products.AsNoTracking().Include(product => product.image).Select(product => new ProductViewModel {image = product.image, location = product.location, Name = product.Name, description = product.description, Id = product.Id, price = product.price }).ToListAsync();
        }

        public async Task<List<ProductViewModel>> GetAllOnHomepageAsync()
        {
            return await _dbContext.products.AsNoTracking().Include(product => product.image)
                .Where(product => product.onHomepage == true)
                .Select(product => new ProductViewModel { image = product.image, location = product.location, Name = product.Name, description = product.description, Id = product.Id, price = product.price }).ToListAsync();
        }

        public async Task<List<ProductViewModel>> GetSpecificProductsAsync(int? catagoryId, string? query)
        {
            var request = _dbContext.products.AsNoTracking();

            if(catagoryId != null) {request = request.Where(product => product.catagory.Id == catagoryId); }

            if (query != null) { request = request.Where(product => product.Name.Contains(query) ); }; 

            return await request.Select(product => new ProductViewModel { image = product.image, location = product.location, Name = product.Name, description = product.description, Id = product.Id, price = product.price }).ToListAsync();
        }
    }
}
