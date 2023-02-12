using Abstractions;
using Abstractions.Entities;
using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class TaxeService : ITaxeService
    {
        private readonly ITaxeRepository _taxeRepository;
        private readonly IMunicipalityRepository _municipalityRepository;
        private readonly ITaxeOrderRepository _taxeOrderRepository;

        public TaxeService(
            ITaxeRepository taxeRepository,
            IMunicipalityRepository municipalityRepository
,           ITaxeOrderRepository taxeOrderRepository)
        {
            _taxeRepository = taxeRepository;
            _municipalityRepository = municipalityRepository;
            _taxeOrderRepository = taxeOrderRepository;
        }

        public async Task Add(AddTaxeModel model)
        {
            var entity = new Taxe
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Value = model.Value,
                MunicipalityId = model.MunicipalityId,
                TaxeTypeId = model.TaxeTypeId,
            };


            await _taxeRepository.Add(entity);
        }

        public async Task<TaxeModel> Get(string name, DateTime date)
        {
            var municipality =  await _municipalityRepository.GetByName(name).FirstOrDefaultAsync();

            if (municipality == null)
            {
                throw new ArgumentException();
            }

            var taxesGroupedByType = municipality.Taxes.GroupBy(u => u.TaxeTypeId);

            var order = await _taxeOrderRepository.GetByMunicipalityId(municipality.Id).ToListAsync();

            var firstInOrder = order.FirstOrDefault(u => u.ParentId == null);

            return await GetTaxe(firstInOrder, order, taxesGroupedByType, date);
        }

        private async Task<TaxeModel> GetTaxe(TaxeOrder firstInOrder, List<TaxeOrder> order, IEnumerable<IGrouping<Guid,Taxe>> taxesGroupedByType, DateTime date)
        {
            var taxe = taxesGroupedByType.FirstOrDefault(u => u.Key == firstInOrder.TaxeTypeId)?
                                         .FirstOrDefault(u => date >= u.StartDate && (!u.EndDate.HasValue || u.EndDate >= date));

            if (taxe != null)
            {
                return new TaxeModel
                {
                    Municipality = taxe.Municipality.Name,
                    Date = date,
                    Value = taxe.Value
                };
            }

            var nextOrderId = order.FirstOrDefault(u => u.ParentId == firstInOrder.Id);
            if (nextOrderId == null)
            {
                throw new KeyNotFoundException();
            }

            return await GetTaxe(nextOrderId, order, taxesGroupedByType, date);
        }
    }
}
