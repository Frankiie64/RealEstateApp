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
    public class SavePropertyViewModel
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int Code { get; set; }
        public int Room { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public double Meters { get; set; }
        public int Bathroom { get; set; }
        public string ImageUrl { get; set; }
        public int AgentId { get; set; }
        public IFormFile File { get; set; }

        //Combobox
        public int TypePropertyId { get; set; }
        public List<TypePropertyViewModel> TypeProperties { get; set; }

        public int TypeSaleId { get; set; }
        public List<TypeSaleViewModel> TypeSales { get; set; }
    }
}
