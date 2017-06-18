namespace TicTacToeTester {
    using NUnit.Framework;
    using TicTacToe;
    public class InitialStateTester {

        [TestFixture]
        public class Fire_MoveFound_event {

            [Test]
            public void if_Board_contains_no_moves_by_either_player() {
                var game = new GameContextMock();
                game.ComputerPlayer = new RandomMoveMaker(game.Board);

                for (int column = 0; column < 3; column++)
                    for (int row = 0; row < 3; row++)
                        game.Board.Add(new Move(new Position(column, row)));

                Position? position = null;

                var initialState = new InitialGameState(game);
                initialState.MoveFound += (s, e) => {
                    position = e.Position;
                };
                initialState.PlayRound();

                Assert.IsTrue(position?.Column >= 0 && position?.Column < 3);
                Assert.IsTrue(position?.Row >= 0 && position?.Row < 3);
            }

            [Test]
            public void if_Board_already_contains_move_by_user() {
                var game = new GameContextMock();
                game.ComputerPlayer = new RandomMoveMaker(game.Board);

                for (int column = 0; column < 3; column++)
                    for (int row = 0; row < 3; row++)
                        game.Board.Add(new Move(new Position(column, row)));

                game.Board[new Position(0, 0)].Player = PositionBelongsTo.User;

                Position? position = null;

                var initialState = new InitialGameState(game);
                initialState.MoveFound += (s, e) => {
                    position = e.Position;
                };
                initialState.PlayRound();

                Assert.IsTrue(position?.Column >= 0 && position?.Column < 3);
                Assert.IsTrue(position?.Row >= 0 && position?.Row < 3);
            }
        }

        [TestFixture]
        public class Next_state_should {

            [Test]
            public void not_change_if_board_contains_more_than_six_available_moves() {
                var game = new GameContextMock();
                game.ComputerPlayer = new RandomMoveMaker(game.Board);


                for (int column = 0; column < 3; column++)
                    for (int row = 0; row < 3; row++)
                        game.Board.Add(new Move(new Position(column, row)));

                var initialState = new InitialGameState(game);
                game.State = initialState;

                game.Board[new Position(1,1)].Player = PositionBelongsTo.User;
                initialState.PlayRound();
                Assert.IsInstanceOf<InitialGameState>(game.State);
                game.Board.Reset();

                initialState.PlayRound();
                Assert.IsInstanceOf<InitialGameState>(game.State);
            }

            [Test]
            public void not_change_if_board_contains_no_user_moves() {
                var game = new GameContextMock();
                game.ComputerPlayer = new RandomMoveMaker(game.Board);

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