namespace TicTacToe.Game.State {
    using System;
    using System.Linq;
    public class TwoMovesLeftEndGameState : IGameState {

        public TwoMovesLeftEndGameState(IGameState state) : this(state.Context) { }

        public TwoMovesLeftEndGameState(IGameContext context) {
            Context = context;
        }

        public IGameContext Context { get; private set; }

        public event EventHandler<MoveFoundEventArgs> MoveFound;

        public void PlayRound() {
            CheckToSeeIfLastMoveWonGame();

            Position computerChosenPosition = Context.ComputerPlayer.MakeMove();
            MoveFound?.Invoke(this, new MoveFoundEventArgs(computerChosenPosition));

            CheckToSeeIfLastMoveWonGame();

            throw new GameHasEndedInTieException();
        }

        private void CheckToSeeIfLastMoveWonGame() {
            Move lastMove = Context.MoveHistory.Last();
            Context.Judge.ChecksToSeeIfGameHasBeenWonWith(lastMove);
        }

    }
}