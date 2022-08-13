using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace WebAPI.RealEstateApp.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwggaerExtensions(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "RealEstateApp API");
                opt.DefaultModelRendering(ModelRendering.Model);
            });
        }
    }
}
