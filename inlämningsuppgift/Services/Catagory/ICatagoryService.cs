using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static inlämningsuppgift.Pages.Admin.Catagory.CatagoryAdminIndexModel;

namespace inlämningsuppgift.Services.Catagory
{
   public interface ICatagoryService
    {
        abstract public Task<List<Models.CatagoryViewModel>> GetAllCatagoriesAsync();

        abstract public Task<List<Models.CatagoryViewModel>> GetAllOnHomepage();
        abstract public Task<CatagoryDataModel> GetById(int id);

        abstract public Task<List<string>> GetAllCatagoryNamesAsync();
        abstract public Task<Models.Catagory> GetCatagoryByName(string name);
        abstract public Task SaveNewCatagory(CatagoryDataModel catagory);
        abstract public Task UpdateCatagory(CatagoryDataModel catagory);
        abstract public Task DeleteCatagory(int id);





    }
}
