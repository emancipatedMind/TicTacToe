namespace TicTacToeTester {
    using NUnit.Framework;
    using TicTacToe;
    public class JudgeTester {

        [TestFixture]
        public class If_user_has {

            [Test]
            public void submitted_winning_position_judge_should_return_true() {
                MoveCollection board = new MoveCollection();
                var judge = new Judge(board);

                for (int column = 0; column < 3; column++)
                    for (int row = 0; row < 3; row++)
                        board.Add(new Move(new Position(column, row)));

                Move[] game = new Move[] {
                    new Move(PositionBelongsTo.User, new Position(0, 1)),
                    new Move(PositionBelongsTo.Computer, new Position(2, 0)),
                    new Move(PositionBelongsTo.User, new Position(1, 1)),
                    new Move(PositionBelongsTo.Computer, new Position(2, 1)),
                };

                Position[] winningPositions = new Position[] {
                    new Position(2, 1),
                };

                foreach(var move in game)
                    board[move.Position].Player = move.Player;

                foreach (var position in winningPositions)
                    Assert.IsTrue(judge.HasDeterminedThatUserWonGameWith(position));
            }

            [Test]
            public void submitted_neutral_position_judge_should_return_false() {
                MoveCollection board = new MoveCollection();
                var judge = new Judge(board);

                for (int column = 0; column < 3; column++)
                    for (int row = 0; row < 3; row++)
                        board.Add(new Move(new Position(column, row)));

                Move[] game = new Move[] {
                    new Move(PositionBelongsTo.User, new Position(0, 1)),
                    new Move(PositionBelongsTo.Computer, new Position(1, 1)),
                    new Move(PositionBelongsTo.User, new Position(1, 2)),
                    new Move(PositionBelongsTo.Computer, new Position(2, 0)),
                };

                Position[] winningPositions = new Position[] {
                    new Position(0, 2),
                };

                foreach(var move in game)
                    board[move.Position].Player = move.Player;

                foreach (var position in winningPositions)
                    Assert.IsFalse(judge.HasDeterminedThatUserWonGameWith(position));
            }
        }

    }
}