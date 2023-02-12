using Abstractions;
using Abstractions.Entities;
using System.Threading.Tasks;

namespace Sql
{
    public class TaxeRepository : ITaxeRepository
    {
        private readonly TaxesDbContext _context;

        public TaxeRepository(TaxesDbContext context)
        {
            _context = context;
        }
        public async Task Add(Taxe entity)
        {
            _context.Taxes.Add(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
