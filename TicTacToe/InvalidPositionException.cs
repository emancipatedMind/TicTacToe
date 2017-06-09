namespace TicTacToe {
    public class InvalidPositionException : System.ApplicationException {
        public InvalidPositionException(string message) : base(message) { }
    }
}