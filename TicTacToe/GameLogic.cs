namespace TicTacToe {
    using System;
    using System.Collections.Generic;
    public class GameLogic {

        private Dictionary<PlayerIs, Position> _positions = new Dictionary<PlayerIs, Position>();

        public GameLogic() { }
        public GameLogic(Dictionary<PlayerIs, Position> positions) {
            _positions = new Dictionary<PlayerIs, Position>(positions);
        }

        public event EventHandler MoveFound;

        public void PlayRound(Position position) {
            _positions.Add(PlayerIs.User, position);
            ProcessRound();
        }

        public void PlayRound() =>
            ProcessRound();

        private void ProcessRound() {
            if (_positions.Count == 0) {
                MoveFound?.Invoke(this, EventArgs.Empty);
                return;
            }
            MoveFound?.Invoke(this, EventArgs.Empty);
        }

    }
}