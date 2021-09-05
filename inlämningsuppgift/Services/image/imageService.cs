using inlämningsuppgift.Models;
using inlämningsuppgift.Services.image;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace inlämningsuppgift.Services
{
    public class imageService : IImageService
    {
        private ApplicationDbContext _dbContext;

         private Models.image defaultImageEntity { get; set; }
        public imageService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
             defaultImageEntity = _dbContext.images.AsNoTracking().First(image => image.url == "/images/default.png");
        }


        public Models.image GetDefaultImageEntity()
        {
            return defaultImageEntity;
        }

        public string GetDefaultImageUrl()
        {
            return defaultImageEntity.url;
        }

        public string GetDefaultImageAltText()
        {
            return defaultImageEntity.altText;
        }
    }
}
