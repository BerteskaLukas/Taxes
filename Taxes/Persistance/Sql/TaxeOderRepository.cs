using Abstractions;
using Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sql
{
    public class TaxeOderRepository : ITaxeOrderRepository
    {
        private readonly TaxesDbContext _context;

        public TaxeOderRepository(TaxesDbContext context)
        {
            _context= context;
        }

        public async Task CreateDedaultOrder(List<TaxeOrder> order)
        {
            for (int i = 0; i < order.LongCount(); i++)
            {
                if (i > 0)
                {
                    order[i].ParentId = order[i-1].Id;
                }
                _context.TaxeOrders.Add(order[i]);
            }

            await _context.SaveChangesAsync();
        }

        public IQueryable<TaxeOrder> GetByMunicipalityId(Guid id)
        {
            return _context.TaxeOrders.Include(u => u.TaxeType).Where(u => u.MunicipalityId == id);
        }

        public async Task UpdateOrder(List<TaxeOrder> order)
        {
            Guid municipalityId = order.FirstOrDefault().MunicipalityId;
            var oldOrdre = await _context.TaxeOrders.Where(u => u.MunicipalityId == municipalityId).ToListAsync();

            oldOrdre.ForEach(u =>
            {
                u.ParentId = order.FirstOrDefault(z => z.Id == u.Id).ParentId;
            });

            await _context.SaveChangesAsync();
        }
    }
}
