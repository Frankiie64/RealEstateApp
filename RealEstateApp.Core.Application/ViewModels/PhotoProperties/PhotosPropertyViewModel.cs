using RealEstateApp.Core.Application.ViewModels.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.ViewModels.PhotoProperties
{
    public class PhotosPropertyViewModel
    {
        public int Id { get; set; }
        public string ImagUrl { get; set; }
        public int IdProperty { get; set; }
        public PropertyViewModel Property { get; set; }
    }
}
