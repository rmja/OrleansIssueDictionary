namespace Grains.Contracts
{
    public readonly struct HashValue
    {
        public string Value { get; }

        public HashValue(string value)
        {
            Value = value;
        }
    }
}
