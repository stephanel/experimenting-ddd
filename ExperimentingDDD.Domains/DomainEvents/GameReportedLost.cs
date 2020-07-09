namespace ExperimentingDDD.Domains.DomainEvents
{
    public class GameReportedLost : IDomainEvent
    {
        public int ErrorCode => ErrorCodes.GameReportedLost;
    }
}
