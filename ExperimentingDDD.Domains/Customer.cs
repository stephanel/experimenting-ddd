using ExperimentingDDD.Domains.DomainEvents;
using System.Collections.Generic;

namespace ExperimentingDDD.Domains
{
    public class Customer
    {
        public List<Game> GamesDeclaredLost { get; private set; }

        public bool IsPreferred { get; private set; } = false;

        private Customer()
        { }

        public static Customer Load(List<Game> gamesDeclaredLost)
        {
            return new Customer()
            {
                GamesDeclaredLost = gamesDeclaredLost
            };
        }

        public void DoSomething()
        {
            IsPreferred = true;
            DomainEventsHandler.Raise(new CustomerBecamePreferred() { Customer = this });
        }
    }
}
