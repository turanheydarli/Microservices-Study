using ESourcing.Sourcing.Data;
using ESourcing.Sourcing.Data.Interfaces;
using ESourcing.Sourcing.Repositories;
using ESourcing.Sourcing.Repositories.Interfaces;
using ESourcing.Sourcings.Settings;
using ESourcing.Sourcings.Settings.Interfaces;
using Microsoft.Extensions.Options;

namespace ESourcing.Sourcings.System
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomizedDataStore(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SourcingDatabaseSettings>(configuration.GetSection(nameof(SourcingDatabaseSettings)));
            services.AddSingleton<ISourcingDatabaseSettings>
                (sp => sp.GetRequiredService<IOptions<SourcingDatabaseSettings>>().Value);

            services.AddTransient<ISourcingContext, SourcingContext>();
            services.AddScoped<IAuctionRepository, AuctionRepository>();

            return services;
        }
    }
}
