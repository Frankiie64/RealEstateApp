﻿using RealEstateApp.Core.Application.Dtos.Improvement;
using RealEstateApp.Core.Application.Dtos.PropertyImprovement;
using RealEstateApp.Core.Application.Dtos.TypeProperty;
using RealEstateApp.Core.Application.Dtos.TypeSale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Dtos.Property
{
    public class PropertyDto
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Location { get; set; }
        public int Room { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public double Meters { get; set; }
        public int Bathroom { get; set; }
        public int AgentId { get; set; }        
        public string AgentName { get; set; }

        public int TypePropertyId { get; set; }
        public TypePropertyDto TypeProperty { get; set; }

        public int TypeSaleId { get; set; }
        public TypeSaleDto TypeSale { get; set; }

        public ICollection<PropertyImprovementDto> PropertyImprovements { get; set; } //last
        public ICollection<ImprovementDto> Improvements { get; set; }

    }
}