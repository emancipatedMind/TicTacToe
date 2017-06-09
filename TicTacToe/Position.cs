namespace TicTacToe {
    public struct Position {

        public int Column { get; private set; }
        public int Row { get; private set; }

        public Position(int column, int row) : this() {
            Column = column;
            Row = row;
        }

        public override string ToString() =>
            $"[{nameof(Column)},{Column};{nameof(Row)},{Row}]";

        public override int GetHashCode() =>
            ToString().GetHashCode();

        public override bool Equals(object obj) =>
            obj is Position && GetHashCode() == obj.GetHashCode();

        public static bool operator ==(Position p1, Position p2) =>
            p1.Row == p2.Row && p1.Column == p2.Column;

        public static bool operator !=(Position p1, Position p2) =>
            !(p1 == p2);

    }
}