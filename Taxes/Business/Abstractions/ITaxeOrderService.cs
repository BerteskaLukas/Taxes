using Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abstractions
{
    public interface ITaxeOrderService
    {
        Task<IEnumerable<TaxeOrderModel>> GetByMunicipalityId(Guid municipalityId);
        Task UpdateOrder(Guid municipalityId, List<UpdateTaxeOrderModel> order);
    }
}
