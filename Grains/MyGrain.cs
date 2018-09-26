using Grains.Contracts;
using Orleans;
using Orleans.Concurrency;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grains
{
    public class MyGrain : Grain, IMyGrain
    {
        private IReadOnlyDictionary<int, Container> _value;

        public Task SetAsync(Immutable<IReadOnlyDictionary<int, Container>> containers)
        {
            _value = containers.Value;

            return Task.CompletedTask;
        }

        public Task<Immutable<IReadOnlyDictionary<int, Container>>> GetAsync()
        {
            return Task.FromResult(_value.AsImmutable());
        }
    }
}
