using ExperimentingDDD.Domains.Messages;

namespace ExperimentingDDD.Domains.MessageHandlers
{
    public class AddGameToCartMessageHandler : BaseMessageHandler<AddGameToCartMessage>
    {
        public override void Handle(AddGameToCartMessage message)
        {
            TradeInCart cart = message.Cart;
            Game game = message.Game;

            cart.Add(game);
        }
    }
}
