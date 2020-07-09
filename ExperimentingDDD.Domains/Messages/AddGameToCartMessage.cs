namespace ExperimentingDDD.Domains.Messages
{
    public class AddGameToCartMessage
    {
        public TradeInCart Cart { get; private set; }
        public Game Game { get; private set; }

        private AddGameToCartMessage()
        { }

        public static AddGameToCartMessage Load(Game game, TradeInCart cart)
        {
            return new AddGameToCartMessage()
            {
                Game = game,
                Cart = cart
            };
        }
    }
}