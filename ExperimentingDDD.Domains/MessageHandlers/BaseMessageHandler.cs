namespace ExperimentingDDD.Domains.MessageHandlers
{
    public abstract class BaseMessageHandler<T>
    {
        public abstract void Handle(T message);
    }
}