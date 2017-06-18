namespace TicTacToe {
    using System.Linq;
    public class ComputerPlayer : IMoveMaker {

        MoveCollection _board;
        IMoveMaker _logicalMover;
        IMoveMaker _randomMover;

        public ComputerPlayer(MoveCollection board) {
            _board = board;
            var randomMover = new RandomMoveMaker(board);
            var strategicMover = new StrategicMoveLocator(board, randomMover);
            var winningMover = new WinningMoveLocator(board, strategicMover);

            _randomMover = randomMover;
            _logicalMover = winningMover;
        }

        public Position MakeMove() {
            if (LogicalMoveUnnecessary) return RandomMove;
            return LogicalMove;
        }

        private bool LogicalMoveUnnecessary {
            get {
                var availableMoveCount = _board.Where(m => m.Player == PositionBelongsTo.NoOne).ToArray().Length;
                return availableMoveCount >= 7 || availableMoveCount == 1;
            }
        }

        private Position RandomMove => _randomMover.MakeMove();
        private Position LogicalMove => _logicalMover.MakeMove();

    }
}
