using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using RealEstateApp.Application.Services;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.Services.ServicesApp;
using MediatR;
using RealEstateApp.Core.Application.Interfaces.Service.Service_App;
using RealEstateApp.Core.Application.Interfaces.Service.Service_Api;
using RealEstateApp.Core.Application.Services.ServicesApi;

namespace RealEstateApp.Core.Application
{
    public static class ServicesRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region AutoMapper

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #endregion
            #region Services 

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserServiceApi, UserServiceApi>();

            services.AddTransient(typeof(IGenericServices<,,>), typeof(GenericServices<,,>));

            #region ServicesApp

            services.AddTransient<IPropertyService, PropertyServices>();
            services.AddTransient<ITypePropertyService, TypePropertyServices>();
            services.AddTransient<IPhotosOfPropertyService, PhotosOfPropertyService>();
            services.AddTransient<IFavoritePropertyServices, FavoritePropertyServices>();
            services.AddTransient<ITypeSaleService, TypeSaleServices>();
            services.AddTransient<IImprovementService, ImprovementServices>();
            services.AddTransient<ITypeImpromentsServices, TypeImpromentServices>();
            services.AddTransient<IRequestService, RequestService>();


            /*
            services.AddTransient<IImprovementService, IMPRO>();
            services.AddTransient<IPropertyImprovementService, PhotosOfPropertyService>();
            services.AddTransient<ITypePropertyService, PhotosOfPropertyService>();

            */

            #endregion

            #region ServiceApi

            #endregion
            services.AddMediatR(Assembly.GetExecutingAssembly());
            #endregion
        }
    }
}
