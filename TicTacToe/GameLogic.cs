namespace TicTacToe {
    using Game;
    using System;
    using ToolkitNFW4.XAML;
    public class GameLogic {

        GameContext _model = new GameContext();
        DelegateCommand _playRoundCommand;
        DelegateCommand _startRoundCommand;

        public GameLogic() {
            _model.GameHasEndedInTie += (s, e) => GameHasEndedInTie?.Invoke(this, e);
            _model.GameHasBeenWon += (s, e) => GameHasBeenWon?.Invoke(this, e);
        }

        public event EventHandler GameHasEndedInTie;
        public event EventHandler<GameHasBeenWonEventArgs> GameHasBeenWon;

        public DelegateCommand PlayRound => _playRoundCommand ??
            (_playRoundCommand = new DelegateCommand(o => _model.PlayRound((Position)o)));

        public DelegateCommand StartRound => _startRoundCommand ??
            (_startRoundCommand = new DelegateCommand(o => _model.PlayRound()));

    }
}