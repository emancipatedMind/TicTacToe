namespace TicTacToe {
    using System;
    public class EndGameState : IGameState {

        public EndGameState(IGameState state) : this(state.Context) { }

        public EndGameState(IGameContext context) {
            Context = context;
        }

        public IGameContext Context { get; private set; }

        public event EventHandler<MoveFoundEventArgs> MoveFound;

        public void PlayRound() {
        }

    }
}