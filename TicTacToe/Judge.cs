namespace TicTacToe {
    using System.Linq;
    public class Judge {

        MoveCollection _board;
        WinningSetRetriever _winningSetRetriever = new WinningSetRetriever();

        public Judge(MoveCollection board) {
            _board = board;
        }

        public bool HasDeterminedThatUserWonGameWith(Position latestPosition) {
            Position[] userPositions = _board.Where(m => m.Player == PositionBelongsTo.User).Select(m => m.Position).ToArray();
            Position[][] possibleWinningPositions = _winningSetRetriever.GetWinningPositions(latestPosition);
            foreach(Position[] set in possibleWinningPositions) {
                if (userPositions.Contains(set[0]) && userPositions.Contains(set[1]))
                    return true;
            }
            return false;
        }

    }
}