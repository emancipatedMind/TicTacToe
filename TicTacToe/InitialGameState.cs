namespace TicTacToe {
    using System;
    using System.Linq;
    public class InitialGameState : IGameState {

        public InitialGameState(IGameState state) : this(state.Context) { }

        public InitialGameState(IGameContext context) {
            Context = context;
        }

        public IGameContext Context { get; private set; }

        public event EventHandler<MoveFoundEventArgs> MoveFound;

        public void PlayRound() {
            Position computerChosenPosition = Context.ComputerPlayer.MakeMove();
            Context.Board[computerChosenPosition].Player = PositionBelongsTo.Computer;
            MoveFound?.Invoke(this, new MoveFoundEventArgs(computerChosenPosition));
            if (NextRoundWillHaveEnoughPositionsForAWinner)
                Context.State = new EndGameState(this);
        }

        private bool NextRoundWillHaveEnoughPositionsForAWinner {
            get {
                int availableMoveCount = Context.Board.Where(x => x.Player == PositionBelongsTo.NoOne).ToArray().Length;
                return availableMoveCount < 7;
            }
        }

    }
}