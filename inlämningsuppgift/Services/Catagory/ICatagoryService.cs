using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inlämningsuppgift.Services.Catagory
{
   public interface ICatagoryService
    {
        abstract public Task<List<Models.CatagoryViewModel>> GetAllCatagoriesAsync();

    }
}
