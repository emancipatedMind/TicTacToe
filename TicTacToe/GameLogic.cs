namespace TicTacToe {
    using System;
    public class GameLogic {

        public event EventHandler MoveFound;

        public void PlayRound() {
            MoveFound?.Invoke(this, EventArgs.Empty);
        }

    }
}