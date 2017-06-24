namespace TicTacToe {
    using Game;
    using System;
    using System.Collections.Generic;
    using ToolkitNFW4.XAML;
    public class GameLogic : EntityBase {

        GameContext _model = new GameContext();
        DelegateCommand _startRoundCommand;

        public GameLogic() {
            foreach (var b in _model.Board) {
                ButtonViewModelList.Add(new ButtonViewModel(b));
            }
            _model.GameHasEndedInTie += (s, e) => GameHasEndedInTie?.Invoke(this, e);
            _model.GameHasBeenWon += (s, e) => GameHasBeenWon?.Invoke(this, e);
            PlayRound = new DelegateCommand(o => _model.PlayRound((Position)o));
        }

        public event EventHandler GameHasEndedInTie;
        public event EventHandler<GameHasBeenWonEventArgs> GameHasBeenWon;

        public List<ButtonViewModel> ButtonViewModelList { get; } = new List<ButtonViewModel>();

        public DelegateCommand PlayRound { get; private set; }

        public DelegateCommand StartRound => _startRoundCommand ??
            (_startRoundCommand = new DelegateCommand(o => _model.PlayRound()));

    }
}