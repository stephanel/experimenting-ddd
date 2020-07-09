namespace ExperimentingDDD.Domains.Messages
{
    public class CustomerDoSomethingMessage
    {
        public Customer Customer { get; private set; }

        private CustomerDoSomethingMessage()
        { }

        public static CustomerDoSomethingMessage Load(Customer customer)
        {
            return new CustomerDoSomethingMessage()
            {
                Customer = customer
            };
        }
    }
}