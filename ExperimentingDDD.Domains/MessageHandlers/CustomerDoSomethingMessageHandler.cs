using ExperimentingDDD.Domains.Messages;

namespace ExperimentingDDD.Domains.MessageHandlers
{
    public class CustomerDoSomethingMessageHandler : BaseMessageHandler<CustomerDoSomethingMessage>
    {
        public override void Handle(CustomerDoSomethingMessage message)
        {
            Customer customer = message.Customer;

            customer.DoSomething();
        }
    }
}
