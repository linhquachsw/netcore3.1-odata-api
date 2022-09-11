using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.Extensions.DependencyInjection;
using Netpower.Contracts.Models;
using Netpower.Core.Options;

namespace Netpower.Core.Service.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            return services.AddVersioning()
                .AddSwaggerVersioning()
            .AddODataExtensions();
        }

        private static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'api-demo'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            return services;
        }

        private static IServiceCollection AddSwaggerVersioning(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.ConfigureOptions<ConfigureSwaggerOptions>();

            return services;
        }

        private static IServiceCollection AddODataExtensions(this IServiceCollection services)
        {
            var batchHandler = new DefaultODataBatchHandler(); // use OData batching
            services.AddControllers()
                .AddOData(opt => opt.AddRouteComponents("odata/v{v:apiVersion}", EdmModelBuilder.Build(), batchHandler)
                    .Count()
                    .Filter()
                    .OrderBy()
                    .Expand()
                    .Select()
                    .SetMaxTop(25)
                );

            return services;
        }
    }
}