using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inlämningsuppgift.Services.image
{
   public interface IImageService
    {
        public string GetDefaultImageUrl();
        public string GetDefaultImageAltText();
    }
}
