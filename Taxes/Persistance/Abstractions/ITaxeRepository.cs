

using Abstractions.Entities;
using System.Threading.Tasks;

namespace Abstractions
{
    public interface ITaxeRepository
    {
        Task Add(Taxe entity);
    }
}
