namespace TicTacToe.Computer {
    using System.Linq;
    public class Judge {

        MoveCollection _board;
        WinningSetRetriever _winningSetRetriever = new WinningSetRetriever();

        public Judge(MoveCollection board) {
            _board = board;
        }

        public void ChecksToSeeIfUserEndedGameWith(Position latestPosition) {
            CheckIfGameHasBeenWon(PositionBelongsTo.User, latestPosition);
        }

        public void ChecksToSeeIfComputerEndedGameWith(Position latestPosition) {
            CheckIfGameHasBeenWon(PositionBelongsTo.Computer, latestPosition);
        }

        private void CheckIfGameHasBeenWon(PositionBelongsTo player, Position latestPosition) {
            Position[] playerPositions = _board.Where(m => m.Player == player).Select(m => m.Position).ToArray();
            Position[][] possibleWinningPositions = _winningSetRetriever.GetWinningPositions(latestPosition);
            foreach(var set in possibleWinningPositions) {
                if (playerPositions.Contains(set[0]) && playerPositions.Contains(set[1]))
                    throw new GameHasBeenWonException();
            }
        }

    }
}