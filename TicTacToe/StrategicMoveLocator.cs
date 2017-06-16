namespace TicTacToe {
    using System.Linq;
    public class StrategicMoveLocator : IMoveMaker {

        private MoveCollection _board;
        private IMoveMaker _successor;
        private Position _strategicMove;
        private WinningSetRetriever _winningSetRetriever = new WinningSetRetriever();

        public StrategicMoveLocator(MoveCollection board, IMoveMaker successor) {
            _board = board;
            _successor = successor;
        }

        public Position MakeMove() {
            if (StrategicMoveAvailable) return _strategicMove;
            else return _successor.MakeMove();
        }

        private bool StrategicMoveAvailable {
            get {
                Position[] userPosition = _board.Where(m => m.Player == PositionBelongsTo.User).Select(m => m.Position).ToArray(); 
                Position[] availablePositions = _board.Where(m => m.Player == PositionBelongsTo.NoOne).Select(m => m.Position).ToArray(); 
                foreach (var position in userPosition) {
                    var winningSets = _winningSetRetriever.GetWinningPositions(position);
                    foreach (var set in winningSets) {
                        for (int i = 0; i < 2; i++) {
                            Position linkingPosition = set[i];
                            _strategicMove = set[i == 0 ? 1 : 0];
                            if (userPosition.Contains(linkingPosition) && availablePositions.Contains(_strategicMove))
                                return true;
                        }
                    }
                }
                return false;
            }
        }

    }
}