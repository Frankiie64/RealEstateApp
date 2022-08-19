using RealEstateApp.Core.Application.ViewModels.Improvement;
using RealEstateApp.Core.Application.ViewModels.PhotoProperties;
using RealEstateApp.Core.Application.ViewModels.TypeImproments;
using RealEstateApp.Core.Application.ViewModels.TypeProperty;
using RealEstateApp.Core.Application.ViewModels.TypeSale;
using RealEstateApp.Core.Application.ViewModels.Users;
using System;
using System.Collections.Generic;

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
        public UserVM agent { get; set; }
        public string AgentId { get; set; }
        public int TypePropertyId { get; set; }
        public TypePropertyViewModel TypeProperty { get; set; }
        public int TypeSaleId { get; set; }
        public TypeSaleViewModel TypeSale { get; set; }
        public List<PhotosPropertyViewModel> UrlPhotos { get; set; }
        public List<TypeImpromentsViewModel> TypeImproments { get; set; }
        public List<ImprovementViewModel> Improvements { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Creadted { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public bool IsFavorite { get; set; } = false;

    }
}
