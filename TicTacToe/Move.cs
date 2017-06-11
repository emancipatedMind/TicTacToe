namespace TicTacToe {
    public class Move {

        public PositionBelongsTo Player { get; set; }
        public Position Position { get; private set; }

        public Move(Position position) : this(PositionBelongsTo.NoOne, position) { }

        public Move(PositionBelongsTo player, Position position) {
            Player = player;
            Position = position;
        }

    }
}