namespace TicTacToe {
    using System.Linq;
    public class Judge {

        MoveCollection _board;
        WinningSetRetriever _winningSetRetriever = new WinningSetRetriever();

        public Judge(MoveCollection board) {
            _board = board;
        }

        public void ChecksToSeeIfUserEndedGameWith(Position latestPosition) {
            CheckIfGameHasBeenWon(PositionBelongsTo.User, latestPosition);
            CheckToSeeIfGameHasEndedInTie();
        }

        public void ChecksToSeeIfComputerEndedGameWith(Position latestPosition) {
            CheckIfGameHasBeenWon(PositionBelongsTo.Computer, latestPosition);
            CheckToSeeIfGameHasEndedInTie();
        }

        private void CheckIfGameHasBeenWon(PositionBelongsTo player, Position latestPosition) {
            Position[] positions = _board.Where(m => m.Player == player).Select(m => m.Position).ToArray();
            Position[][] possibleWinningPositions = _winningSetRetriever.GetWinningPositions(latestPosition);
            foreach(Position[] set in possibleWinningPositions) {
                if (positions.Contains(set[0]) && positions.Contains(set[1]))
                    throw new GameHasBeenWonException();
            }
        }

        private void CheckToSeeIfGameHasEndedInTie() {
            var availableMoveCount = _board.Where(m => m.Player == PositionBelongsTo.NoOne).ToArray().Length;
            if (availableMoveCount == 0)
                throw new GameHasEndedInTieException();
        }

    }
}