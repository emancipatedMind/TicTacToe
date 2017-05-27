namespace TicTacToe {
    public class WinningMoveFoundException : System.ApplicationException {
        public Location Move { get; private set; }
        public WinningMoveFoundException(Location moveFound) {
            Move = moveFound;
        }
    }
}