﻿using AutoMapper;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.Dtos.Agent;
using RealEstateApp.Core.Application.Dtos.Improvement;
using RealEstateApp.Core.Application.Dtos.Property;
using RealEstateApp.Core.Application.Dtos.TypeProperty;
using RealEstateApp.Core.Application.Dtos.TypeSale;
using RealEstateApp.Core.Application.Features.Agent.Commands.ChangeAgentStatus;
using RealEstateApp.Core.Application.Features.Improvements.Commands.CreateImprovement;
using RealEstateApp.Core.Application.Features.Improvements.Commands.UpdateImprovement;
using RealEstateApp.Core.Application.Features.TypeProperties.Commands.CreateTypeProperty;
using RealEstateApp.Core.Application.Features.TypeProperties.Commands.UpdateTypeProperty;
using RealEstateApp.Core.Application.Features.TypeSales.Commands.CreateTypeSale;
using RealEstateApp.Core.Application.Features.TypeSales.Commands.UpdateTypeSale;
using RealEstateApp.Core.Application.ViewModels.Improvement;
using RealEstateApp.Core.Application.ViewModels.PhotoProperties;
using RealEstateApp.Core.Application.ViewModels.Property;
using RealEstateApp.Core.Application.ViewModels.TypeProperty;
using RealEstateApp.Core.Application.ViewModels.TypeSale;
using RealEstateApp.Core.Application.ViewModels.Users;
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

            CreateMap<AuthenticationResponse, UserVM>()
               .ForMember(x => x.Properties, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(x => x.HasError, opt => opt.Ignore())
               .ForMember(x => x.Error, opt => opt.Ignore());

            CreateMap<AuthenticationResponse, AgentDto>()
               .ForMember(x => x.PropertiesQuantity, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(x => x.HasError, opt => opt.Ignore())
               .ForMember(x => x.Error, opt => opt.Ignore());
            ////


            CreateMap<AuthenticationResponse, ChangeAgentStatusCommand>()
               .ForMember(x => x.PropertiesQuantity, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(x => x.HasError, opt => opt.Ignore())
               .ForMember(x => x.JWTtoken, opt => opt.Ignore())
               .ForMember(x => x.Error, opt => opt.Ignore())
               .ForMember(x => x.RefreshToken, opt => opt.Ignore())
               .ForMember(x => x.Error, opt => opt.Ignore());

            CreateMap<AuthenticationResponse, AgentChangeStatusResponse>()
               .ForMember(x => x.PropertiesQuantity, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(x => x.HasError, opt => opt.Ignore())
               .ForMember(x => x.JWTtoken, opt => opt.Ignore())
               .ForMember(x => x.Error, opt => opt.Ignore())
               .ForMember(x => x.RefreshToken, opt => opt.Ignore())
               .ForMember(x => x.Error, opt => opt.Ignore());

            CreateMap<AuthenticationResponse, RegisterRequest>()
               .ForMember(x => x.ConfirmPassword, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(x => x.JWTtoken, opt => opt.Ignore())
               .ForMember(x => x.Error, opt => opt.Ignore())
               .ForMember(x => x.HasError, opt => opt.Ignore())
               .ForMember(x => x.RefreshToken, opt => opt.Ignore())
               .ForMember(x => x.Error, opt => opt.Ignore());


            //A ver si sirve   ------------------>
            CreateMap<UserVM, ChangeAgentStatusCommand>()
               .ForMember(x => x.PropertiesQuantity, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(x => x.Properties, opt => opt.Ignore());

            CreateMap<RegisterRequest, ChangeAgentStatusCommand>()
               .ForMember(x => x.PropertiesQuantity, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<UserVM, AgentChangeStatusResponse>()
               .ForMember(x => x.PropertiesQuantity, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(x => x.Properties, opt => opt.Ignore());

            CreateMap<UserVM, ChangeAgentStatusCommand>()
               .ForMember(x => x.PropertiesQuantity, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(x => x.Properties, opt => opt.Ignore());

            CreateMap<SaveUserVM, UserVM>()
               .ForMember(x => x.Properties, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(x => x.Password, opt => opt.Ignore())
               .ForMember(x => x.ConfirmPassword, opt => opt.Ignore())
               .ForMember(x => x.Error, opt => opt.Ignore())
               .ForMember(x => x.HasError, opt => opt.Ignore());

            //CreateMap<SaveUserVM, ChangeAgentStatusCommand>() //
            //   .ForMember(x => x.PropertiesQuantity, opt => opt.Ignore())
            //   .ForMember(x => x.IsVerified, opt => opt.Ignore())
            //   .ReverseMap()
            //                  .ForMember(x => x.Password, opt => opt.Ignore())
            //   .ForMember(x => x.ConfirmPassword, opt => opt.Ignore())
            //   .ForMember(x => x.Error, opt => opt.Ignore())
            //   .ForMember(x => x.HasError, opt => opt.Ignore());

            //CreateMap<SaveUserVM, RegisterRequest>()
            //   .ForMember(x => x.IsVerified, opt => opt.Ignore())
            //   .ReverseMap()
            //   .ForMember(x => x.Error, opt => opt.Ignore())
            //   .ForMember(x => x.HasError, opt => opt.Ignore());
            // ------------------------->


            //CreateMap<AgentDto, UserVM>()
            //   .ReverseMap()
            //   .ForMember(x => x.PropertiesQuantity, opt => opt.Ignore());


            CreateMap<Property, PropertyViewModel>()
               .ForMember(x => x.agent, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<Property, SavePropertyViewModel>()
               .ForMember(x => x.File, opt => opt.Ignore())
               .ForMember(x => x.UrlPhotos, opt => opt.Ignore())
               .ReverseMap()
                .ForMember(x => x.UrlPhotos, opt => opt.Ignore())
               .ForMember(x => x.Improvements, opt => opt.Ignore());

            CreateMap<PropertyViewModel, SavePropertyViewModel>()
                .ForMember(x => x.UrlPhotos, opt => opt.Ignore())
               .ForMember(x => x.File, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(x => x.agent, opt => opt.Ignore());

            CreateMap<Improvement, ImprovementViewModel>()
               .ReverseMap();

            CreateMap<Improvement, SaveImprovementViewModel>()
               .ReverseMap()
               .ForMember(x => x.Property, opt => opt.Ignore());

            CreateMap<ImprovementViewModel, SaveImprovementViewModel>()
               .ReverseMap()
               .ForMember(x => x.Property, opt => opt.Ignore());


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

            CreateMap<PhotosOfProperties, PhotosPropertyViewModel>()
             .ReverseMap();

            CreateMap<PhotosPropertyViewModel, SavePhotosPropertyViewModel>()
              .ReverseMap()
              .ForMember(x => x.Property, opt => opt.Ignore());

            CreateMap<PhotosOfProperties, SavePhotosPropertyViewModel>()
              .ReverseMap()
              .ForMember(x => x.Property, opt => opt.Ignore());
            #region DTO's

            CreateMap<Property, PropertyDto>()
                .ForMember(x => x.User, opt => opt.Ignore())
               .ReverseMap()
                .ForMember(x => x.Creadted, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore());


            CreateMap<Improvement, ImprovementDto>()
               .ReverseMap()
                .ForMember(x => x.Creadted, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore());

            CreateMap<Improvement, SaveImprovementDto>()
               .ReverseMap()
               .ForMember(x => x.Property, opt => opt.Ignore())
                .ForMember(x => x.Creadted, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore());

            CreateMap<Improvement, CreateImprovementDto>()
               .ReverseMap()
               .ForMember(x => x.Id, opt => opt.Ignore())
               .ForMember(x => x.Property, opt => opt.Ignore())
                .ForMember(x => x.Creadted, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore());



            CreateMap<TypeProperty, TypePropertyDto>()
               .ReverseMap()
               .ForMember(x => x.Properties, opt => opt.Ignore())
                .ForMember(x => x.Creadted, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore());

            CreateMap<TypeProperty, SaveTypePropertyDto>()
               .ReverseMap()
               .ForMember(x => x.Properties, opt => opt.Ignore())
                .ForMember(x => x.Creadted, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore());

            CreateMap<TypeProperty, CreateTypePropertyDto>()
               .ReverseMap()
               .ForMember(x => x.Id, opt => opt.Ignore())
               .ForMember(x => x.Properties, opt => opt.Ignore())
                .ForMember(x => x.Creadted, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore());



            CreateMap<TypeSale, TypeSaleDto>()
               .ReverseMap()
               .ForMember(x => x.Properties, opt => opt.Ignore())
               .ForMember(x => x.Properties, opt => opt.Ignore())
                .ForMember(x => x.Creadted, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore());

            CreateMap<TypeSale, SaveTypeSaleDto>()
               .ReverseMap()
               .ForMember(x => x.Properties, opt => opt.Ignore())
               .ForMember(x => x.Properties, opt => opt.Ignore())
                .ForMember(x => x.Creadted, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore());

            CreateMap<TypeSale, CreateTypeSaleDto>()
               .ReverseMap()
               .ForMember(x => x.Id, opt => opt.Ignore())
               .ForMember(x => x.Properties, opt => opt.Ignore())
                .ForMember(x => x.Creadted, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore());


                     //CQRS & MEDIATOR

            CreateMap<CreateImprovementCommand, Improvement>()
                .ForMember(x => x.Property, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UpdateImprovementCommand, Improvement>()
                .ForMember(x => x.Property, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ImprovementUpdateResponse, Improvement>()
              .ForMember(x => x.Property, opt => opt.Ignore())
              .ForMember(x => x.LastModified, opt => opt.Ignore())
              .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
              .ForMember(x => x.CreatedBy, opt => opt.Ignore())
              .ReverseMap();



            CreateMap<CreateTypePropertyCommand, TypeProperty>()
                .ForMember(x => x.Properties, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UpdateTypePropertyCommand, TypeProperty>()
                .ForMember(x => x.Properties, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<TypePropertyUpdateResponse, TypeProperty>()
              .ForMember(x => x.Properties, opt => opt.Ignore())
              .ForMember(x => x.LastModified, opt => opt.Ignore())
              .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
              .ForMember(x => x.CreatedBy, opt => opt.Ignore())
              .ReverseMap();



            CreateMap<CreateTypeSaleCommand, TypeSale>()
                .ForMember(x => x.Properties, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UpdateTypeSaleCommand, TypeSale>()
                .ForMember(x => x.Properties, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<TypeSaleUpdateResponse, TypeSale>()
              .ForMember(x => x.Properties, opt => opt.Ignore())
              .ForMember(x => x.LastModified, opt => opt.Ignore())
              .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
              .ForMember(x => x.CreatedBy, opt => opt.Ignore())
              .ReverseMap();
            #endregion

        }
    }
}
