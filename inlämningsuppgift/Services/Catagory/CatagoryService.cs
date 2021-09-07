using inlämningsuppgift.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static inlämningsuppgift.Pages.Admin.Catagory.CatagoryAdminIndexModel;

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

        public async Task<List<string>> GetAllCatagoryNamesAsync()
        {
            return await _dbContext.catagories.Select(catagory => catagory.Name).ToListAsync();
        }

        public async Task<Models.Catagory> GetCatagoryByName(string name)
        {
            return await _dbContext.catagories.FirstAsync(catagory => catagory.Name == name);
        }

        public async Task<CatagoryDataModel> GetById(int id)
        {
            return await _dbContext.catagories
                .Where(x => x.Id == id)
                .Select(x => new CatagoryDataModel {id = x.Id, name = x.Name, image = x.image, onHomepage = x.onHomepage }).FirstOrDefaultAsync();
        }

        public async Task SaveNewCatagory(CatagoryDataModel catagory)
        {
            var Catagory = new Models.Catagory
            {
                Name = catagory.name,
                image = catagory.image,
                onHomepage = catagory.onHomepage
            };

            _dbContext.catagories.Add(Catagory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCatagory(CatagoryDataModel catagory)
        {

            var Catagory = await _dbContext.catagories.FindAsync(catagory.id);

            Catagory.Name = catagory.name;
            Catagory.image = catagory.image;
            Catagory.onHomepage = catagory.onHomepage;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCatagory(int id)
        {
            var entity = await _dbContext.catagories.FindAsync(id);

            _dbContext.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
