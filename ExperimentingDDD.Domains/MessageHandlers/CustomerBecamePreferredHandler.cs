using ExperimentingDDD.Domains.DomainEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExperimentingDDD.Domains.MessageHandlers
{
    public class CustomerBecamePreferredHandler : IHandles<CustomerBecamePreferred>
    {
        public void Handle(CustomerBecamePreferred args)
        {
            // do something
        }
    }
}
