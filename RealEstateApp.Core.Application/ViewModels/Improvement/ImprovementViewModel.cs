using RealEstateApp.Core.Application.ViewModels.PropertyImprovement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.ViewModels.Improvement
{
    public class ImprovementViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<PropertyImprovementViewModel> PropertyImprovements { get; set; }

    }
}
