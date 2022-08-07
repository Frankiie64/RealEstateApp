using AutoMapper;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.ViewModels.Improvement;
using RealEstateApp.Core.Application.ViewModels.Property;
using RealEstateApp.Core.Application.ViewModels.PropertyImprovement;
using RealEstateApp.Core.Application.ViewModels.TypeProperty;
using RealEstateApp.Core.Application.ViewModels.TypeSale;
using RealEstateApp.Core.Domain.Entities;

namespace RealEstateApp.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            /*
            CreateMap<RegisterUserDto, RegisterRequest>()
             .ForMember(x => x.Id, opt => opt.Ignore())
             .ForMember(x => x.Rol, opt => opt.Ignore())
             .ReverseMap();

            CreateMap<AuthenticationRequest, LoginVM>()
               .ForMember(x => x.HasError, opt => opt.Ignore())
               .ForMember(x => x.Error, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<RegisterRequest, SaveUserVM>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ForgotPassowordRequest, ForgotPasswordVM>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ResetPasswordRequest, ResetPasswordVM>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<AuthenticationResponse, UserVM>()
               .ReverseMap()
               .ForMember(x => x.HasError, opt => opt.Ignore())
               .ForMember(x => x.Error, opt => opt.Ignore());
            */



            CreateMap<Property, PropertyViewModel>()
               .ReverseMap()
               .ForMember(x => x.PropertyImprovements, opt => opt.Ignore())
               .ForMember(x => x.Improvements, opt => opt.Ignore());

            CreateMap<Property, SavePropertyViewModel>()
               .ForMember(x => x.File, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(x => x.PropertyImprovements, opt => opt.Ignore())
               .ForMember(x => x.Improvements, opt => opt.Ignore());

            CreateMap<PropertyViewModel, SavePropertyViewModel>()
               .ForMember(x => x.File, opt => opt.Ignore())
               .ReverseMap();



            CreateMap<Improvement, ImprovementViewModel>()
               .ReverseMap()
               .ForMember(x => x.Properties, opt => opt.Ignore());

            CreateMap<Improvement, SaveImprovementViewModel>()
               .ReverseMap()
               .ForMember(x => x.PropertyImprovements, opt => opt.Ignore())
               .ForMember(x => x.Properties, opt => opt.Ignore());

            CreateMap<ImprovementViewModel, SaveImprovementViewModel>()
               .ReverseMap()
               .ForMember(x => x.PropertyImprovements, opt => opt.Ignore());



            CreateMap<TypeProperty, TypePropertyViewModel>()
               .ReverseMap();

            CreateMap<TypeProperty, SaveTypePropertyViewModel>()
               .ReverseMap()
               .ForMember(x => x.Properties, opt => opt.Ignore());

            CreateMap<TypePropertyViewModel, SaveTypePropertyViewModel>()
               .ReverseMap()
               .ForMember(x => x.Properties, opt => opt.Ignore());



            CreateMap<TypeSale, TypeSaleViewModel>()
               .ReverseMap();

            CreateMap<TypeSale, SaveTypeSaleViewModel>()
               .ReverseMap()
               .ForMember(x => x.Properties, opt => opt.Ignore());

            CreateMap<TypeSaleViewModel, SaveTypeSaleViewModel>()
               .ReverseMap()
               .ForMember(x => x.Properties, opt => opt.Ignore());



            CreateMap<PropertyImprovement, PropertyImprovementViewModel>()
               .ReverseMap();

            CreateMap<PropertyImprovement, SavePropertyImprovementViewModel>()
               .ReverseMap()
               .ForMember(x => x.Property, opt => opt.Ignore())
               .ForMember(x => x.Improvement, opt => opt.Ignore());


            CreateMap<PropertyImprovementViewModel, SavePropertyImprovementViewModel>()
               .ReverseMap()
               .ForMember(x => x.Property, opt => opt.Ignore())
               .ForMember(x => x.Improvement, opt => opt.Ignore());



        }
    }
}
