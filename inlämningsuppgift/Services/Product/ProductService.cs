using inlämningsuppgift.enums;
using inlämningsuppgift.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static inlämningsuppgift.Pages.Admin.Product.createNewModel;

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
            return await _dbContext.products.AsNoTracking().Include(product => product.image).Select(product => new ProductViewModel
            {
                catagoryName = product.catagory.Name,
                image = product.image,
                location = product.location,
                Name = product.Name,
                description = product.description,
                Id = product.Id,
                price = product.price
            }).ToListAsync();
        }

        public async Task<List<ProductViewModel>> GetAllOnHomepageAsync()
        {
            return await _dbContext.products.AsNoTracking().Include(product => product.image)
                .Where(product => product.onHomepage == true)
                .Select(product => new ProductViewModel
                {
                    catagoryName = product.catagory.Name,
                    image = product.image,
                    location = product.location,
                    Name = product.Name,
                    description = product.description,
                    Id = product.Id,
                    price = product.price
                }).ToListAsync();
        }

        public async Task<ProductPageDataModel> GetSpecificProductsAsync(int? catagoryId, string? query, priceOrder? priceOrder, int page = 0)
        {
            var request = _dbContext.products.AsNoTracking();

            var productPage = new ProductPageDataModel();

            if (catagoryId != null) { request = request.Where(product => product.catagory.Id == catagoryId); }

            if (query != null) { request = request.Where(product => product.Name.Contains(query) || ((string)(object)product.location).Contains(query)); };

            if (priceOrder != null)
            {
                switch (priceOrder)
                {
                    case enums.priceOrder.Highest:
                        request = request.OrderByDescending(x => x.price);
                        break;

                    case enums.priceOrder.Lowest:
                        request = request.OrderBy(x => x.price);
                        break;
                }
            }

                productPage.possibleResults = request.Count();


                request = request.Skip(page * 3).Take(3);

               productPage.products =  await request.Select(product => new ProductViewModel
            {
                catagoryName = product.catagory.Name,
                image = product.image,
                location = product.location,
                Name = product.Name,
                description = product.description,
                Id = product.Id,
                price = product.price
            }).ToListAsync();

            return productPage;
        }


        public async Task<List<AdminProductViewModel>> GetProductsAdminAsync(string? query)
        {
            var request = _dbContext.products.AsNoTracking();
            if (query != null) { request = request.Where(product => product.Name.Contains(query)); };
            return await request.Select(product => new AdminProductViewModel { Name = product.Name, id = product.Id }).ToListAsync();
        }


        public async Task SaveNewProduct(productDataModel product)
        {
            var enity = new Models.Product
            {
                Name = product.Name,
                description = product.description,
                image = product.image,
                location = product.location,
                onHomepage = product.onHomepage,
                price = product.price,
                catagory = product.catagory
            };
            _dbContext.Add(enity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProduct(productDataModel product)
        {
            var entity = _dbContext.products.Find(product.id);

            entity.image = product.image;
            entity.Name = product.Name;
            entity.catagory = product.catagory;
            entity.description = product.description;
            entity.onHomepage = product.onHomepage;
            entity.location = product.location;
            entity.price = product.price;

            await _dbContext.SaveChangesAsync();
        }


        public async Task DeleteProductByIdAsync(int id)
        {
            var entity = await _dbContext.products.FindAsync(id);
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<productDataModel> GetProductById(int id)
        {
            return await _dbContext.products.AsNoTracking().Include(x => x.catagory).Include(x => x.image)
                .Where(product => product.Id == id)
                .Select(x => new productDataModel
                {
                    id = x.Id,
                    Name = x.Name,
                    catagory = x.catagory,
                    description = x.description,
                    image = x.image,
                    location = x.location,
                    onHomepage = x.onHomepage,
                    price = x.price
                }).FirstAsync();
        }

         public async Task<ProductViewModel> GetProductViewById(int id)
        {
            return await _dbContext.products.AsNoTracking().Include(product => product.image)
                .Where(product => product.Id == id)
                .Select(product => new ProductViewModel
            {
                catagoryName = product.catagory.Name,
                image = product.image,
                location = product.location,
                Name = product.Name,
                description = product.description,
                Id = product.Id,
                price = product.price
            }).FirstOrDefaultAsync();
        }

    }
}
