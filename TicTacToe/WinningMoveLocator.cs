namespace TicTacToe {
    public class WinningMoveLocator : IMoveMaker {

        private MoveCollection _board;
        private IMoveMaker _successor;
        private Position _winningMove;

        public WinningMoveLocator(MoveCollection board, IMoveMaker successor) {
            _board = board;
            _successor = successor;
        } 

        public Position MakeMove() {
            if (WinningMoveAvailable) return _winningMove;
            else return _successor.MakeMove();
        }

        private bool WinningMoveAvailable {
            get { return true; }
        }
    }
}