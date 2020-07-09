namespace ExperimentingDDD.Domains.DomainEvents
{
    public class MaxNumberOfSameGamePerCartReached : IDomainEvent
    {
        public int ErrorCode => ErrorCodes.MaxNumberOfSameGamePerCartReached;
    }
}
