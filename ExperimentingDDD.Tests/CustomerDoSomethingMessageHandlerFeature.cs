using ExperimentingDDD.Domains;
using ExperimentingDDD.Domains.DomainEvents;
using ExperimentingDDD.Domains.MessageHandlers;
using ExperimentingDDD.Domains.Messages;
using System.Collections.Generic;
using Xunit;

namespace ExperimentingDDD.Tests
{
    public class CustomerDoSomethingMessageHandlerFeature
    {
        private readonly CustomerDoSomethingMessageHandler _sut;

        public CustomerDoSomethingMessageHandlerFeature()
        {
            _sut = new CustomerDoSomethingMessageHandler();
        }

        [Fact]
        public void DoSomethingShouldMakeCustomerPreferred()
        {
            var customer = Customer.Load(new List<Game>());
            Customer preferred = null;

            DomainEventsHandler.Register<CustomerBecamePreferred>(
                p => preferred = p.Customer
            );

            var message = CustomerDoSomethingMessage.Load(customer);

            _sut.Handle(message);

            Assert.True(customer.IsPreferred);
            Assert.Equal(preferred, customer);
        }
    }
}
