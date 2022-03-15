using ESourcing.Products.Data;
using ESourcing.Products.Data.Interfaces;
using ESourcing.Products.Repositories;
using ESourcing.Products.Repositories.Interfaces;
using ESourcing.Products.Settings;
using Microsoft.Extensions.Options;

namespace ESourcing.Products.System
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomizedDataStore(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<ProductDatabaseSettings>(
                configuration.GetSection(nameof(ProductDatabaseSettings)));
            services.AddScoped<IProductDatabaseSettings>
                (sp =>
                    sp.GetRequiredService<IOptions<ProductDatabaseSettings>>().Value
                );

            services.AddScoped<IProductContext, ProductContext>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
