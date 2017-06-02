namespace TicTacToe {
    public struct Move {

        public PlayerIs Player { get; private set; }
        public Position Position { get; private set; }

        public Move(PlayerIs player, Position position) : this() {
            Player = player;
            Position = position;
        } 

    }
}