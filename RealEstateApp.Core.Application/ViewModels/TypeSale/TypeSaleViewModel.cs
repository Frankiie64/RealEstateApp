using RealEstateApp.Core.Application.ViewModels.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.ViewModels.TypeSale
{
    public class TypeSaleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PropertiesQuantity { get; set; }

        public ICollection<PropertyViewModel> Properties { get; set; }

    }

}
