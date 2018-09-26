using Grains;
using Grains.Contracts;
using Orleans;
using Orleans.Concurrency;
using Orleans.Hosting;
using Orleans.TestingHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class Tests
    {
        private readonly IGrainFactory _grainFactory;

        public Tests()
        {
            var cluster = new TestClusterBuilder(1).Build();

            cluster.Deploy();

            _grainFactory = cluster.Client;
        }

        [Fact]
        public async Task ShouldSendDictionaryWithReadonlyStructValue()
        {
            var grain = _grainFactory.GetGrain<IMyGrain>(Guid.NewGuid().ToString());

            var hash = new Hash()
            {
                { 123, new HashValue("value")  }
            };

            var dictionary = new Dictionary<int, HashValue>()
            {
                { 123, new HashValue("value")  }
            };

            var container = new Container(hash, dictionary);

            var setValue = new Dictionary<int, Container>()
            {
                { 1, container }
            };

            Assert.NotEmpty(setValue[1].Hash);
            Assert.NotEmpty(setValue[1].Dictionary);

            await grain.SetAsync(setValue.AsImmutable<IReadOnlyDictionary<int, Container>>());

            var getValue = await grain.GetAsync();

            Assert.NotEmpty(getValue.Value[1].Hash);
            Assert.NotEmpty(getValue.Value[1].Dictionary);
        }
    }
}
