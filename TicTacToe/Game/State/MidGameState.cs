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
            Position usersLastMove = Context.MoveHistory.Last().Position;
            Context.Judge.ChecksToSeeIfUserEndedGameWith(usersLastMove);

            Position computerChosenPosition = Context.ComputerPlayer.MakeMove();
            Context.Board[computerChosenPosition].Player = PositionBelongsTo.Computer;
            MoveFound?.Invoke(this, new MoveFoundEventArgs(computerChosenPosition));
            Context.Judge.ChecksToSeeIfComputerEndedGameWith(computerChosenPosition);

            if (TwoMovesLeft)
                Context.State = new TwoMovesLeftEndGameState(this);
            else if (OnlyOneMoveLeft)
                Context.State = new NoComputerMoveEndGameState(this);

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