using Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions
{
    public interface IMunicipalityRepository
    {
        Task<Guid> Add(string name);
        IQueryable<Municipality> GetByName(string name);
    }
}
