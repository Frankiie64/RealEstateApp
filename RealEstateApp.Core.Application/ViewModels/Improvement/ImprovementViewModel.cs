using RealEstateApp.Core.Application.ViewModels.Property;
using RealEstateApp.Core.Application.ViewModels.TypeImproments;
using System.Collections.Generic;

namespace RealEstateApp.Core.Application.ViewModels.Improvement
{
    public class ImprovementViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<TypeImpromentsViewModel> typeImproments { get; set; }

    }
}
