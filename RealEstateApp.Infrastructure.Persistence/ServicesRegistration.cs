using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Infrastructure.Persistence.Context;
using RealEstateApp.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Infrastructure.Persistence
{
    public static class ServicesRegistration
    {

        //Se le conoce como un Extension Methods - Decorator
        public static void AddPersitsenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Configuration of Database
            if (configuration.GetValue<bool>("UseInMemoryDataBase"))
            {
                //Base de datos de texteo
                services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("DBRealEstateApp"));
            }
            else
            {
                // Base de datos en producion

                services.AddDbContext<ApplicationDbContext>(Options =>
                Options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }
            #endregion

            #region Dependency Injection

            //Generics
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //Other repos
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IImprovementRepository, ImprovementRepository>();
            services.AddTransient<ITypePropertyRepository, TypePropertyRepository>();
            services.AddTransient<ITypeSaleRepository, TypeSaleRepository>();
            services.AddTransient<IPhotosPropertyRepository, PhotosPropertyRepository>();
            services.AddTransient<IFavoritePropertyRepository, FavoritePropertyRepository>();
            services.AddTransient<ITypeImpromentRepository, TypeImpromentsRepository>();
            services.AddTransient<IRequestRepository, RequestRepository>();

            #endregion

        }
    }
}