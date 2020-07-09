namespace ExperimentingDDD.Domains.DomainEvents
{
    public interface IHandles<T>
    {
        void Handle(CustomerBecamePreferred args);
    }
}