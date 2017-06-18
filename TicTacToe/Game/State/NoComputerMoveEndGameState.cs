namespace TicTacToe.Game.State {
    using System;
    using System.Linq;
    public class NoComputerMoveEndGameState : IGameState {

        public NoComputerMoveEndGameState(IGameState state) : this(state.Context) { }

        public NoComputerMoveEndGameState(IGameContext context) {
            Context = context;
        }

        public IGameContext Context { get; private set; }

        public event EventHandler<MoveFoundEventArgs> MoveFound;

        public void PlayRound() {
            Position usersLastMove = Context.MoveHistory.Last().Position;
            Context.Judge.ChecksToSeeIfUserEndedGameWith(usersLastMove);

            throw new GameHasEndedInTieException();
        }

    }
}