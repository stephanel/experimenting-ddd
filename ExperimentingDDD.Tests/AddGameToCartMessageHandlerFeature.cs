using ExperimentingDDD.Domains;
using ExperimentingDDD.Domains.DomainEvents;
using ExperimentingDDD.Domains.MessageHandlers;
using ExperimentingDDD.Domains.Messages;
using System.Collections.Generic;
using Xunit;

namespace ExperimentingDDD.Tests
{
    public class AddGameToCartMessageHandlerFeature
    {
        static Game Castelvania = Game.Load("Castelvania");
        static Game DonkeyKong = Game.Load("Donkey Kong");
        static Game QBert = Game.Load("Q*Bert");
        static Game PacMan = Game.Load("Pac-Man");
        static Game MarioBros = Game.Load("Mario Bros.");
        static Game Tetris = Game.Load("Tetris");
        static Game Zelda = Game.Load("The Legend of Zelda");

        private readonly AddGameToCartMessageHandler _sut;

        public AddGameToCartMessageHandlerFeature()
        {
            _sut = new AddGameToCartMessageHandler();
        }

        [Fact]
        public void ShouldAddGameInCart()
        {
            // Arrange
            var message = AddGameToCartMessage.Load(
                PacMan,
                TradeInCart.Load(
                    Customer.Load(new List<Game>())
                )
            );

            // Act
            _sut.Handle(message);

            // Assert
            Assert.Single(message.Cart.LineItems);
        }

        [Fact]
        public void ShouldRaiseCartIsFullNotificationWhenMaxItemsAreAlreadyInCart()
        {
            // Arrange
            var customer = Customer.Load(new List<Game>());
            int? errorCode = null;

            DomainEventsHandler.Register<CartIsFull>(
                p => errorCode = p.ErrorCode
            );

            var message = AddGameToCartMessage.Load(
                PacMan, 
                TradeInCart.Load(customer));

            // add 10 games
            message.Cart.Add(Castelvania);
            message.Cart.Add(DonkeyKong);
            message.Cart.Add(Castelvania);
            message.Cart.Add(MarioBros);
            message.Cart.Add(PacMan);
            message.Cart.Add(PacMan);
            message.Cart.Add(QBert);
            message.Cart.Add(QBert);
            message.Cart.Add(Tetris);
            message.Cart.Add(Zelda);

            // Act
            _sut.Handle(message);

            // Assert
            Assert.Equal(ErrorCodes.CartIsFull, errorCode);
        }

        [Fact]
        public void ShouldRaiseMaxNumberOfSameGamePerCartReachedNotificationWhenTheMaxNumberOfGameIsAlreadyInCart()
        {
            // Arrange
            var gameToAdd = PacMan;
            var customer = Customer.Load(new List<Game>());
            int? errorCode = null;

            DomainEventsHandler.Register<MaxNumberOfSameGamePerCartReached>(
                p => errorCode = p.ErrorCode
            );

            var message = AddGameToCartMessage.Load(
                gameToAdd,
                TradeInCart.Load(customer));

            // add 10 games
            message.Cart.Add(gameToAdd);
            message.Cart.Add(gameToAdd);
            message.Cart.Add(gameToAdd);

            // Act
            _sut.Handle(message);

            // Assert
            Assert.Equal(ErrorCodes.MaxNumberOfSameGamePerCartReached, errorCode);
        }

        [Fact]
        public void ShouldRaiseGameReportedLostNotificationWhenGameToAddWasReportedLost()
        {
            // Arrange
            var gameToAdd = PacMan;
            var customer = Customer.Load(new List<Game>() { gameToAdd });
            int? errorCode = null;

            DomainEventsHandler.Register<GameReportedLost>(
                p => errorCode = p.ErrorCode
            );

            var message = AddGameToCartMessage.Load(
                gameToAdd, 
                TradeInCart.Load(customer));

            // Act
            _sut.Handle(message);

            // Assert
            Assert.Equal(ErrorCodes.GameReportedLost, errorCode);
        }
    }
}
