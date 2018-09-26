using Orleans;
using Orleans.Concurrency;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grains.Contracts
{
    public interface IMyGrain : IGrainWithStringKey
    {
        Task SetAsync(Immutable<IReadOnlyDictionary<int, Container>> containers);
        Task<Immutable<IReadOnlyDictionary<int, Container>>> GetAsync();
    }
}
