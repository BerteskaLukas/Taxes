using Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abstractions
{
    public interface ITaxeTypeRepository
    {
        IQueryable<TaxeType> GetAll();
    }
}
