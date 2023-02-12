using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace Sql.Migrations
{
    public class TaxesDbContextMigrationService : IHostedService
    {
        private readonly IServiceScopeFactory _scoperFactory;

        public TaxesDbContextMigrationService(IServiceScopeFactory scoperFactory)
        {
            _scoperFactory = scoperFactory;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using IServiceScope scope = _scoperFactory.CreateScope();
            await scope.ServiceProvider.GetRequiredService<TaxesDbContext>().Database.MigrateAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
