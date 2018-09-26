using System.Collections.Generic;

namespace Grains.Contracts
{
    public class Container
    {
        public Hash Hash { get; set; }
        public Dictionary<int, HashValue> Dictionary { get; set; }

        public Container()
        {
            Hash = new Hash();
            Dictionary = new Dictionary<int, HashValue>();
        }
        
        public Container(Hash hash, Dictionary<int, HashValue> dictionary)
        {
            Hash = hash;
            Dictionary = dictionary;
        }
    }
}
