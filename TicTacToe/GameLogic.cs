namespace TicTacToe {
    using System;
    using System.Collections.Generic;
    public class GameLogic {

        private List<Move> _positions = new List<Move>();

        public GameLogic() { }

        public event EventHandler MoveFound;

        public void PlayRound(Position position) {
            _positions.Add(new Move(PlayerIs.User, position));
            ProcessRound();
        }

        public void PlayRound() =>
            ProcessRound();

        public void LoadGame(IEnumerable<Move> moves) {
            _positions.Clear();
            _positions.AddRange(moves);
        }

        private void ProcessRound() {
            if (_positions.Count == 0) {
                MoveFound?.Invoke(this, EventArgs.Empty);
                return;
            }
            MoveFound?.Invoke(this, EventArgs.Empty);
        }

    }
}