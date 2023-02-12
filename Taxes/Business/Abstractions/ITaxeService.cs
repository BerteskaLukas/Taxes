using Contracts;
using System;
using System.Threading.Tasks;

namespace Abstractions
{
    public interface ITaxeService
    {
        Task<TaxeModel> Get(string municipalityId, DateTime date);
        Task Add(AddTaxeModel model);
    }
}
