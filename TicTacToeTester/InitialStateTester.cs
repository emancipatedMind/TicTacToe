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
            public void change_to_MidGameState_if_enough_moves_for_win_to_be_possible_on_next_move() {
                var game = new GameContextMock();
                game.ComputerPlayer = new RandomMoveMaker(game.Board);

                for (int column = 0; column < 3; column++)
                    for (int row = 0; row < 3; row++)
                        game.Board.Add(new Move(new Position(column, row)));

                var initialState = new InitialGameState(game);
                game.State = initialState;

                game.Board[new Position(1,1)].Player = PositionBelongsTo.User;
                game.Board[new Position(0,1)].Player = PositionBelongsTo.Computer;
                game.Board[new Position(0,0)].Player = PositionBelongsTo.User;
                initialState.PlayRound();
                Assert.IsInstanceOf<MidGameState>(game.State);

                game.State = initialState;
                game.Board.Reset();

                game.Board[new Position(1,1)].Player = PositionBelongsTo.Computer;
                game.Board[new Position(0,0)].Player = PositionBelongsTo.User;
                initialState.PlayRound();
                Assert.IsInstanceOf<MidGameState>(game.State);
            }

            [Test]
            public void not_change_if_not_enough_moves_for_a_win_to_be_possible() {
                var game = new GameContextMock();
                var randomMoveMaker = new RandomMoveMaker(game.Board);
                game.ComputerPlayer = randomMoveMaker;

                for (int column = 0; column < 3; column++)
                    for (int row = 0; row < 3; row++)
                        game.Board.Add(new Move(new Position(column, row)));

                var initialState = new InitialGameState(game);
                game.State = initialState;

                Position userMove = randomMoveMaker.MakeMove();
                game.Board[userMove].Player = PositionBelongsTo.User;
                initialState.PlayRound();
                Assert.IsInstanceOf<InitialGameState>(game.State);
                game.Board.Reset();

                initialState.PlayRound();
                Assert.IsInstanceOf<InitialGameState>(game.State);

            }
        }

    }
}