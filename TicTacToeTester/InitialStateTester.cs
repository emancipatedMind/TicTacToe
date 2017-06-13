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
            initialState.PlayRound();

            Assert.IsTrue(eventFired);
            Assert.IsTrue(position.Column >= 0 && position.Column < 3);
            Assert.IsTrue(position.Row >= 0 && position.Row < 3);
        }

        [Test]
        public void Handle_MoveCollectionContainsOneMoveMadeByUser_MoveFoundEventFiresWithRandomMove() {
            SetUp();

            _contextMock.Board[new Position(0, 0)].Player = PositionBelongsTo.User;

            Position position = new Position();
            bool eventFired = false;

            var initialState = new InitialGameState(_contextMock);
            initialState.MoveFound += (s, e) => {
                eventFired = true;
                position = e.Position;
            };
            initialState.PlayRound();

            Assert.IsTrue(eventFired);
            Assert.IsTrue(position.Column >= 0 && position.Column < 3);
            Assert.IsTrue(position.Row >= 0 && position.Row < 3);
        }

        private void SetUp() {
            _contextMock = new GameContextMock();

            for (int column = 0; column < 3; column++)
                for (int row = 0; row < 3; row++)
                    _contextMock.Board.Add(new Move(new Position(column, row)));
        }

        [TestFixture]
        public class Next_state_should {

            [Test]
            public void not_change_if_board_contains_no_user_moves() {
                var game = new GameContextMock();

                for (int column = 0; column < 3; column++)
                    for (int row = 0; row < 3; row++)
                        game.Board.Add(new Move(new Position(column, row)));

                game.Board[new Position(0, 0)].Player = PositionBelongsTo.User;

                var initialState = new InitialGameState(game);
                game.State = initialState;
                initialState.PlayRound();
                Assert.IsInstanceOf<InitialGameState>(game.State);
            }
        }

    }

}