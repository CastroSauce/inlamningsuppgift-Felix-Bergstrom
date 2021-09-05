using inlämningsuppgift.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inlämningsuppgift.Services.Catagory
{
    public class CatagoryService : ICatagoryService
    {
        private ApplicationDbContext _dbContext { get; }

        public CatagoryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<CatagoryViewModel>> GetAllCatagoriesAsync()
        {
            return await _dbContext.catagories.AsNoTracking().Include(Catagory => Catagory.image).Select(Catagory => new CatagoryViewModel {image = Catagory.image, Name = Catagory.Name, Id = Catagory.Id }).ToListAsync();
        }    
        
        public async Task<List<CatagoryViewModel>> GetAllOnHomepage()
        {
            return await _dbContext.catagories.AsNoTracking().Include(Catagory => Catagory.image)
                .Where(Catagory => Catagory.onHomepage == true)
                .Select(Catagory => new CatagoryViewModel {image = Catagory.image, Name = Catagory.Name, Id = Catagory.Id }).ToListAsync();
        }
    }
}
