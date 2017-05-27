namespace TicTacToe {
    public class MoveFoundException : System.ApplicationException {
        public Location Move { get; private set; }
        public MoveFoundException(Location moveFound) {
            Move = moveFound;
        }
    }
}