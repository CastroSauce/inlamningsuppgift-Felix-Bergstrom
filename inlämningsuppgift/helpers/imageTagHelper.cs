using inlämningsuppgift.Models;
using inlämningsuppgift.Services;
using inlämningsuppgift.Services.image;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inlämningsuppgift.helpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("image",TagStructure = TagStructure.WithoutEndTag)]
    public class imageTagHelper : TagHelper
    {

        public image imageModel { get; set; }

        private IImageService _imageService{ get; }
        public imageTagHelper(IImageService imageService)
        {
            _imageService = imageService;
        }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";

            if (imageModel == null)
            {
                output.Attributes.SetAttribute("src", _imageService.GetDefaultImageUrl());
                output.Attributes.SetAttribute("alt", _imageService.GetDefaultImageAltText());
                return;
            }

            output.Attributes.SetAttribute("src", imageModel.url);
            output.Attributes.SetAttribute("alt", imageModel.altText) ;
        }
    }
}
