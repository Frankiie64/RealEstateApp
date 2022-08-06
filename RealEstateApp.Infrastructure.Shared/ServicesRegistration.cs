using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Domain.Settings;
using RealEstateApp.Infrastructure.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RealEstateApp.Infrastructure.Shared
{
    public static class ServicesRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}