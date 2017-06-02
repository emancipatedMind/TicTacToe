namespace TicTacToe {
    public struct Position {

        public int Column { get; private set; }
        public int Row { get; private set; }

        public Position(int column, int row) : this() {
            Column = column;
            Row = row;
        } 

    }
}