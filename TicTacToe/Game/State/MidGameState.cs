namespace TicTacToe.Game.State {
    using System;
    using System.Linq;
    public class MidGameState : IGameState {

        public MidGameState(IGameState state) : this(state.Context) { }

        public MidGameState(IGameContext context) {
            Context = context;
        }

        public IGameContext Context { get; private set; }

        public event EventHandler<MoveFoundEventArgs> MoveFound;

        public void PlayRound() {
            CheckToSeeIfLastMoveWonGame();

            Position computerChosenPosition = Context.ComputerPlayer.MakeMove();
            MoveFound?.Invoke(this, new MoveFoundEventArgs(computerChosenPosition));

            CheckToSeeIfLastMoveWonGame();

            if (TwoMovesLeft)
                Context.State = new TwoMovesLeftEndGameState(this);
            else if (OnlyOneMoveLeft)
                Context.State = new NoComputerMoveEndGameState(this);

        }

        private void CheckToSeeIfLastMoveWonGame() {
            Move lastMove = Context.MoveHistory.Last();
            Context.Judge.ChecksToSeeIfGameHasBeenWonWith(lastMove);
        }

        private bool TwoMovesLeft {
            get {
                int availableMoveCount = Context.Board.Where(m => m.Player == PositionBelongsTo.NoOne).Count();
                return availableMoveCount == 2;
            }
        }

        private bool OnlyOneMoveLeft {
            get {
                int availableMoveCount = Context.Board.Where(m => m.Player == PositionBelongsTo.NoOne).Count();
                return availableMoveCount == 1;
            }
        }

    }
}