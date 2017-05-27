namespace TicTacToe {
    public class GameWonException : System.ApplicationException {
        public Location[] WinningSet { get; private set; }
        public Pieces Winner { get; private set; }
        public GameWonException(Location[] set, Pieces winner) {
            WinningSet = set;
            Winner = winner;
        }
    }
}