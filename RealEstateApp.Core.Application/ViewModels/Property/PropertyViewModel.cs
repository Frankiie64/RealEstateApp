using Microsoft.AspNetCore.Http;
using RealEstateApp.Core.Application.ViewModels.TypeProperty;
using RealEstateApp.Core.Application.ViewModels.TypeSale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.ViewModels.Property
{
    public class PropertyViewModel
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Location { get; set; }
        public int Room { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public double Meters { get; set; }
        public int Bathroom { get; set; }
        public string ImageUrl { get; set; }
        public int AgentId { get; set; }

        public int TypePropertyId { get; set; }
        public TypePropertyViewModel TypeProperty { get; set; }

        public int TypeSaleId { get; set; }
        public TypeSaleViewModel TypeSale { get; set; }

    }
}
