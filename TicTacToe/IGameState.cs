namespace TicTacToe {
    using System;
    public interface IGameState {
        IGameContext Context { get; }
        void PlayRound();
        event EventHandler<MoveFoundEventArgs> MoveFound;
    }
}