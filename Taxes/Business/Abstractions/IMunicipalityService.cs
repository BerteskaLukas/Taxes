using System;
using System.Threading.Tasks;

namespace Abstractions
{
    public interface IMunicipalityService
    {
        Task<Guid> Add(string name);
    }
}
