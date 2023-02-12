using Abstractions;
using Domain;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class IoCExtensions
    {
        public static void ConfigureTaxesDomainServices (this IServiceCollection services)
        {
            services.AddScoped<ITaxeOrderService, TaxeOrderService>();
            services.AddScoped<ITaxeService, TaxeService>();
            services.AddScoped<IMunicipalityService, MunicipalityService>();
        }
    }
}
