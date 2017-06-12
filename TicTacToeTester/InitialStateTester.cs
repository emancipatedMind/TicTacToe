namespace TicTacToeTester {
    using NUnit.Framework;
    using System;
    using TicTacToe;
    [TestFixture] 
    public class InitialStateTester {

        GameContextMock _contextMock;
        Random _randomizer = new Random();

        [Test]
        public void Handle_MoveCollectionContainsNoMovesByEitherPlayer_MoveFoundEventFiresWithRandomMove() {
            SetUp();

            Position position = new Position();
            bool eventFired = false;

            var initialState = new InitialGameState(_contextMock);
            initialState.MoveFound += (s, e) => {
                eventFired = true;
                position = e.Position;
            };
            initialState.Handle();

            Assert.IsTrue(eventFired);
            Assert.IsTrue(position.Column >= 0 && position.Column < 3);
            Assert.IsTrue(position.Row >= 0 && position.Row < 3);
        }

        [Test]
        public void Handle_MoveCollectionContainsOneMoveMadeByUser_MoveFoundEventFiresWithRandomMove() {
            SetUp();

            _contextMock.Moves[new Position(0, 0)].Player = PositionBelongsTo.User;

            Position position = new Position();
            bool eventFired = false;

            var initialState = new InitialGameState(_contextMock);
            initialState.MoveFound += (s, e) => {
                eventFired = true;
                position = e.Position;
            };
            initialState.Handle();

            Assert.IsTrue(eventFired);
            Assert.IsTrue(position.Column >= 0 && position.Column < 3);
            Assert.IsTrue(position.Row >= 0 && position.Row < 3);
        }

        private void SetUp() {
            _contextMock = new GameContextMock();

            for (int column = 0; column < 3; column++)
                for (int row = 0; row < 3; row++)
                    _contextMock.Moves.Add(new Move(new Position(column, row)));
        }
    }

}