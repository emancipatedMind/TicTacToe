namespace TicTacToe {
    using System;
    public interface IGameState {
        IGameContext Context { get; }
        void Handle();
        event EventHandler<MoveFoundEventArgs> MoveFound;
    }
}