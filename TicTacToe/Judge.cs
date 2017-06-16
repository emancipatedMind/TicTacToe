namespace TicTacToe {
    using System.Linq;
    public class Judge {

        MoveCollection _board;
        WinningSetRetriever _winningSetRetriever = new WinningSetRetriever();

        public Judge(MoveCollection board) {
            _board = board;
        }

        public bool HasDeterminedThatUserWonGameWith(Position latestPosition) =>
            CheckIfGameHasBeenWon(PositionBelongsTo.User, latestPosition);

        public bool HasDeterminedThatComputerWonGameWith(Position latestPosition) =>
            CheckIfGameHasBeenWon(PositionBelongsTo.Computer, latestPosition);

        private bool CheckIfGameHasBeenWon(PositionBelongsTo player, Position latestPosition) {
            Position[] positions = _board.Where(m => m.Player == player).Select(m => m.Position).ToArray();
            Position[][] possibleWinningPositions = _winningSetRetriever.GetWinningPositions(latestPosition);
            foreach(Position[] set in possibleWinningPositions) {
                if (positions.Contains(set[0]) && positions.Contains(set[1]))
                    return true;
            }
            return false;
        }

    }
}