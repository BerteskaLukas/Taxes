using Abstractions;
using Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sql
{
    public class MunicipalityRepository : IMunicipalityRepository
    {
        private readonly TaxesDbContext _context;

        public MunicipalityRepository(TaxesDbContext context)
        {
            _context = context;
        }


        public async Task<Guid> Add(string name)
        {
            var entity = new Municipality { Name = name };
            _context.Municipalities.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public IQueryable<Municipality> GetByName(string name)
        {
            return _context.Municipalities.Include(u => u.Taxes).ThenInclude(u => u.TaxeType).Where(x => x.Name == name);
        }
    }
}
