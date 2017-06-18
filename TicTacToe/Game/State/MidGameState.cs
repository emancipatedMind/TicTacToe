namespace TicTacToe.Game.State {
    using System;
    public class MidGameState : IGameState {

        public MidGameState(IGameState state) : this(state.Context) { }

        public MidGameState(IGameContext context) {
            Context = context;
        }

        public IGameContext Context { get; private set; }

        public event EventHandler<MoveFoundEventArgs> MoveFound;

        public void PlayRound() {
        }

    }
}