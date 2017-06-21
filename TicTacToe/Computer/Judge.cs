namespace TicTacToe.Computer {
    using System.Linq;
    public class Judge {

        MoveCollection _board;
        WinningSetRetriever _winningSetRetriever = new WinningSetRetriever();

        public Judge(MoveCollection board) {
            _board = board;
        }

        public void ChecksToSeeIfGameHasBeenWonWith(Move move) {
            Position[] playerPositions = _board.Where(m => m != move && m.Player == move.Player).Select(m => m.Position).ToArray();
            Position[][] possibleWinningPositions = _winningSetRetriever.GetWinningPositions(move.Position);
            foreach(var set in possibleWinningPositions) {
                if (playerPositions.Contains(set[0]) && playerPositions.Contains(set[1])) {
                    throw new GameHasBeenWonException(move);
                }
            }
        }

    }
}