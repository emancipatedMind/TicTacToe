namespace TicTacToe {
    public class GameHasBeenWonEventArgs : System.EventArgs {
        public Move WinningMove { get; private set; }
        public GameHasBeenWonEventArgs(Move winningMove) {
            WinningMove = winningMove;
        }
    }
}