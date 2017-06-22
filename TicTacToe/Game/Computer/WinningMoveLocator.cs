namespace TicTacToe.Computer {
    using System.Linq;
    public class WinningMoveLocator : IMoveMaker {

        private MoveCollection _board;
        private IMoveMaker _successor;
        private Position _winningMove;
        private WinningSetRetriever _winningSetRetriever = new WinningSetRetriever();

        public WinningMoveLocator(MoveCollection board, IMoveMaker successor) {
            _board = board;
            _successor = successor;
        }

        public Position MakeMove() {
            if (WinningMoveAvailable) return _winningMove;
            else return _successor.MakeMove();
        }

        private bool WinningMoveAvailable {
            get {
                Position[] myPositions = _board.Where(m => m.Player == PositionBelongsTo.Computer).Select(m => m.Position).ToArray();
                Position[] availablePositions = _board.Where(m => m.Player == PositionBelongsTo.NoOne).Select(m => m.Position).ToArray();
                foreach (var position in myPositions) {
                    var winningSets = _winningSetRetriever.GetWinningPositions(position);
                    foreach (var set in winningSets) {
                        for (int i = 0; i < 2; i++) {
                            Position linkingPosition = set[i];
                            _winningMove = set[i == 0 ? 1 : 0];
                            if (myPositions.Contains(linkingPosition) && availablePositions.Contains(_winningMove))
                                return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}
