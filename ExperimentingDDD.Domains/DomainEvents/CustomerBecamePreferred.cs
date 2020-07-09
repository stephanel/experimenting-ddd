namespace ExperimentingDDD.Domains.DomainEvents
{
    public class CustomerBecamePreferred : IDomainEvent
    {
        public Customer Customer { get; set; }
    }
}