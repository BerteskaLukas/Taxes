using Abstractions;
using Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql
{
    public class TaxeTypeRepository : ITaxeTypeRepository
    {
        private readonly TaxesDbContext _conetext;

        public TaxeTypeRepository(TaxesDbContext context)
        {
            _conetext = context;
        }

        public IQueryable<TaxeType> GetAll()
        {
            return _conetext.TaxeTypes;
        }
    }
}
