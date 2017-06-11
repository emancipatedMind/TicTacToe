namespace TicTacToe {
    public struct Move {

        public PositionBelongsTo Player { get; set; }
        public Position Position { get; private set; }

        public Move(PositionBelongsTo player, Position position) : this() {
            Player = player;
            Position = position;
        } 

    }
}