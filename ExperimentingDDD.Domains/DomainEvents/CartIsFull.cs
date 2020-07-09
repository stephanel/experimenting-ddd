using System;
using System.Collections.Generic;
using System.Text;

namespace ExperimentingDDD.Domains.DomainEvents
{
    public class CartIsFull : IDomainEvent
    {
        public int ErrorCode => ErrorCodes.CartIsFull;
    }
}
