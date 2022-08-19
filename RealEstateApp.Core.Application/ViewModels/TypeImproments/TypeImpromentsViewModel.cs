using RealEstateApp.Core.Application.ViewModels.Improvement;
using RealEstateApp.Core.Application.ViewModels.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.ViewModels.TypeImproments
{
    public class TypeImpromentsViewModel
    {
        public int Id { get; set; }
        public int IdProperty { get; set; }
        public PropertyViewModel Property { get; set; }
        public int IdImproment { get; set; }
        public ImprovementViewModel Improvement { get; set; }
    }
}
