namespace TicTacToe {
    public class GameHasBeenWonException : System.ApplicationException {
        public Move WinningMove { get; private set; }
        public GameHasBeenWonException(Move winningMove) {
            WinningMove = winningMove;
        }
    }
}