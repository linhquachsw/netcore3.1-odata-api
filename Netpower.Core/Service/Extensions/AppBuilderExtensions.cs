using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Netpower.Core.Service.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerWithVersioning(this IApplicationBuilder app)
        {
            IServiceProvider services = app.ApplicationServices;
            var provider = services.GetRequiredService<IApiVersionDescriptionProvider>();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, Js, CSS, etc.)
            app.UseSwaggerUI(options =>
            {
                // options.SwaggerEndpoint("/swagger/v1/swagger.json", "OData API V1");

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

            return app;
        }
    }
}