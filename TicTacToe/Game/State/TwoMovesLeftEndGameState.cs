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
            Position usersLastMove = Context.MoveHistory.Last().Position;
            Context.Judge.ChecksToSeeIfUserEndedGameWith(usersLastMove);

            Position computerChosenPosition = Context.ComputerPlayer.MakeMove();
            Context.Board[computerChosenPosition].Player = PositionBelongsTo.Computer;
            MoveFound?.Invoke(this, new MoveFoundEventArgs(computerChosenPosition));
            Context.Judge.ChecksToSeeIfComputerEndedGameWith(computerChosenPosition);

            throw new GameHasEndedInTieException();
        }

    }
}