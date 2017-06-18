namespace TicTacToe {
    using System;
    public class PlayerChangedEventArgs : EventArgs {
        public PositionBelongsTo NewPlayer { get; private set; }
        public PositionBelongsTo OldPlayer { get; private set; }

        public PlayerChangedEventArgs(PositionBelongsTo newPlayer, PositionBelongsTo oldPlayer) {
            NewPlayer = newPlayer;
            OldPlayer = oldPlayer;
        }

    }
}