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
            return await _dbContext.products.AsNoTracking().Select(product => new ProductViewModel { Name = product.Name, description = product.description, Id = product.Id, price = product.price }).ToListAsync();
        }
    }
}
