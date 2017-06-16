namespace TicTacToe {
    using System;
    public class MoveFoundEventArgs : EventArgs {
        public Position Position { get; private set; }
        public MoveFoundEventArgs(Position position) {
            Position = position;
        }
    }
}
