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


        public async Task<List<Models.Product>> GetAllProducts()
        {
            return await _dbContext.products.Include(product => product.catagory).AsNoTracking().ToListAsync();
        }
    }
}
