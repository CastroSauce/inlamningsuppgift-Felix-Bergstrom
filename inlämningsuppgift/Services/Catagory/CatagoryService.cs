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

            


            return await _dbContext.catagories.AsNoTracking().Select(Catagory => new CatagoryViewModel { Name = Catagory.Name, Id = Catagory.Id }).ToListAsync();
        }
    }
}
