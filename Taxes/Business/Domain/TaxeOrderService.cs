using Abstractions;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abstractions.Entities;

namespace Domain
{
    public class TaxeOrderService : ITaxeOrderService
    {
        private readonly ITaxeOrderRepository _taxeOrderRepository;
        private readonly ITaxeTypeRepository _typeRepository;

        public TaxeOrderService(ITaxeOrderRepository taxeOrderRepository, ITaxeTypeRepository taxeTypeRepository)
        {
            _taxeOrderRepository = taxeOrderRepository;
            _typeRepository = taxeTypeRepository;
        }

        public Task UpdateOrder(Guid municipalityId, List<UpdateTaxeOrderModel> order)
        {
            var taxeOrders = order.Select(u => new TaxeOrder
            {
                Id = u.Id,
                ParentId = u.ParentId,
                MunicipalityId = municipalityId
            }).ToList();

            return _taxeOrderRepository.UpdateOrder(taxeOrders);
        }

        public async Task<IEnumerable<TaxeOrderModel>> GetByMunicipalityId(Guid municipalityId)
        {
            var order = await GetTaxeOrderByMunicipalityId(municipalityId);

            if (order.Any())
            {
                return order;
            }

            await CreateDefaultOrder(municipalityId);

            return  await GetTaxeOrderByMunicipalityId(municipalityId);

        }

        private async Task<IEnumerable<TaxeOrderModel>>  GetTaxeOrderByMunicipalityId(Guid municipalityId)
        {
            return await _taxeOrderRepository.GetByMunicipalityId(municipalityId)
                                              .Select(o => new TaxeOrderModel
                                              {
                                                  Id = o.Id,
                                                  ParentId = o.ParentId,
                                                  TypeName = o.TaxeType.Name
                                              })
                                              .ToListAsync();
        }

        private async Task CreateDefaultOrder(Guid municipalityId)
        {
            var allTypes = await _typeRepository.GetAll()
                                                .OrderByDescending(u => u.CreatedAt)
                                                .Select(u => new TaxeOrder
                                                {
                                                   MunicipalityId = municipalityId,
                                                   TaxeTypeId = u.Id
                                                })
                                               .ToListAsync();

             await _taxeOrderRepository.CreateDedaultOrder(allTypes);
        }

    }
}
