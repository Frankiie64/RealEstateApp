﻿using RealEstateApp.Core.Application.ViewModels.Property;

namespace RealEstateApp.Core.Application.ViewModels.Improvement
{
    public class ImprovementViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int IdProperty { get; set; }
        public PropertyViewModel Property { get; set; }
    }
}
