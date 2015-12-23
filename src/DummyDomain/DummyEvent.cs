using System;

namespace DummyDomain
{
    [Serializable]
    public class DummyEvent
    {
        public DummyEvent(string name, decimal amount, DateTime time)
        {
            Name = name;
            Amount = amount;
            Time = time;
        }

        public string Name { get; private set; }

        public decimal Amount { get; private set; }

        public DateTime Time { get; private set; }
    }
}
