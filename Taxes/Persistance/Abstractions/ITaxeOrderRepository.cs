using Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abstractions
{
    public interface ITaxeOrderRepository
    {
        IQueryable<TaxeOrder> GetByMunicipalityId(Guid Id);

        Task CreateDedaultOrder(List<TaxeOrder> order);
        Task UpdateOrder(List<TaxeOrder> order);
    }
}
