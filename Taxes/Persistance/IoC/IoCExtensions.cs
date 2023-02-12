using Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sql;
using Sql.Migrations;

namespace IoC
{
    public static class IoCExtensions
    {
        public static void ConfigureTaxesPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaxesDbContext>(opt => opt.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
            services.AddScoped<ITaxeOrderRepository, TaxeOderRepository>();
            services.AddScoped<ITaxeTypeRepository, TaxeTypeRepository>();
            services.AddScoped<ITaxeRepository, TaxeRepository>();
            services.AddScoped<IMunicipalityRepository, MunicipalityRepository>();
            services.AddHostedService<TaxesDbContextMigrationService>();
        }
    }
}
