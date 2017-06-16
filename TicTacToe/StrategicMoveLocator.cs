namespace TicTacToe {
    public class StrategicMoveLocator : IMoveMaker {

        private MoveCollection _board;
        private IMoveMaker _successor;
        private Position _strategicMove;

        public StrategicMoveLocator(MoveCollection board, IMoveMaker successor) {
            _board = board;
            _successor = successor;
        }

        public Position MakeMove() {
            if (StrategicMoveAvailable) return _strategicMove;
            else return _successor.MakeMove();
        }

        private bool StrategicMoveAvailable {
            get { return true; }
        }

    }
}