namespace TicTacToe {
    using System;
    using System.Windows.Input;
    public class PlayerMoveCommand : ICommand {

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) {
            int playMove = (int)parameter;
            GameLogic.PlayRound(playMove);
        }
    }
}