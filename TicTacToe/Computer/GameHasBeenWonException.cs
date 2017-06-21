namespace TicTacToe.Computer {
    public class GameHasBeenWonException : System.ApplicationException {
        public Move WinningMove { get; private set; }
        public GameHasBeenWonException() { }
        public GameHasBeenWonException(Move winningMove) {
            WinningMove = winningMove;
        }
    }
}