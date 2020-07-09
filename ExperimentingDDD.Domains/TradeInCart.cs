using ExperimentingDDD.Domains.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExperimentingDDD.Domains
{
    public class TradeInCart
    {
        const int MaxItemsPerCart = 10;
        const int MaxNumberOfSameGamePerCart = 3;

        public Customer Customer { get; private set; }

        public List<LineItem> LineItems { get; private set; }

        private TradeInCart()
        { }

        public static TradeInCart Load(Customer customer)
        {
            return new TradeInCart()
            {
                Customer = customer,
                LineItems = new List<LineItem>()
            };
        }

        public void Add(Game game)
        {
            if(LineItems.Count >= MaxItemsPerCart)
            {
                DomainEventsHandler.Raise(new CartIsFull());
                return;
            }

            if(NumberOfGameAlreadyInCart(game) >= MaxNumberOfSameGamePerCart)
            {
                DomainEventsHandler.Raise(new MaxNumberOfSameGamePerCartReached());
                return;
            }

            if(Customer.GamesDeclaredLost.Contains(game))
            {
                DomainEventsHandler.Raise(new GameReportedLost());
                return;
            }

            LineItems.Add(LineItem.Load(game));
        }

        private int NumberOfGameAlreadyInCart(Game game)
        {
            return LineItems
                .Where(x => x.Game == game)
                .Count();
        }
    }
}
