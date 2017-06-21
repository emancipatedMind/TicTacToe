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
            CheckToSeeIfLastMoveWonGame();

            throw new GameHasEndedInTieException();
        }

        private void CheckToSeeIfLastMoveWonGame() {
            Move lastMove = Context.MoveHistory.Last();
            Context.Judge.ChecksToSeeIfGameHasBeenWonWith(lastMove);
        }

    }
}