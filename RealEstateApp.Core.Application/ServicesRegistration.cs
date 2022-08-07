using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using RealEstateApp.Application.Services;

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

            services.AddTransient(typeof(IGenericServices<,,>), typeof(GenericServices<,,>));

            #region ServicesApp

            #endregion

            #region ServiceApi

            #endregion

            #endregion
        }
    }
}
