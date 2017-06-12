namespace TicTacToe {
    using System;
    using System.Linq;
    public class InitialGameState : IGameState {

        public InitialGameState(IGameContext context) {
            Context = context;
            Context.State = this;
        }

        public IGameContext Context { get; private set; }

        public event EventHandler<MoveFoundEventArgs> MoveFound;

        public void PlayRound() {

            var availableMoves = Context.Moves.Where(m => m.Player == PositionBelongsTo.NoOne);
            var userMoves = Context.Moves.Where(m => m.Player == PositionBelongsTo.User);

            var rnd = new Random();
            Move[] currentlyAvailableMoves = availableMoves.ToArray();
            Move selectedMove = currentlyAvailableMoves[rnd.Next(currentlyAvailableMoves.Length)]; 
            selectedMove.Player = PositionBelongsTo.Computer;
            MoveFound?.Invoke(this, new MoveFoundEventArgs(selectedMove.Position));

        }

    }
}