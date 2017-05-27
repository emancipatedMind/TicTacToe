namespace TicTacToe {
    public class GameHasBeenWonEventArgs : System.EventArgs {

        public Location[] WinningSet { get; set; }
        public Pieces WinningPiece { get; set; }

        public GameHasBeenWonEventArgs(Location[] winningSet, Pieces winningPiece) {
            WinningSet = winningSet;
            WinningPiece = winningPiece;
        }

    }
}