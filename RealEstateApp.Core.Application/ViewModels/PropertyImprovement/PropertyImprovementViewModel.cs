using RealEstateApp.Core.Application.ViewModels.Improvement;
using RealEstateApp.Core.Application.ViewModels.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.ViewModels.PropertyImprovement
{
    public class PropertyImprovementViewModel
    {
        public int PropertyId { get; set; }
        public PropertyViewModel Property { get; set; }


        public int ImprovementId { get; set; }
        public ImprovementViewModel Improvement { get; set; }
    }
}
