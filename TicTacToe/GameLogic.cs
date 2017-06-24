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
            _model.GameHasEndedInTie += (s, e) => {
                OnPropertyChanged(nameof(GameOver));
                GameHasEndedInTie?.Invoke(this, e);
            };
            _model.GameHasBeenWon += (s, e) => {
                OnPropertyChanged(nameof(GameOver));
                GameHasBeenWon?.Invoke(this, e);
            };
            PlayRound = new DelegateCommand(o => _model.PlayRound((Position)o));
            Reset = new DelegateCommand(ResetCallback);
        }

        public event EventHandler GameHasEndedInTie;
        public event EventHandler<GameHasBeenWonEventArgs> GameHasBeenWon;

        public List<ButtonViewModel> ButtonViewModelList { get; } = new List<ButtonViewModel>();
        public bool GameOver => _model.GameOver;

        public DelegateCommand PlayRound { get; private set; }
        public DelegateCommand Reset { get; private set; }

        public DelegateCommand StartRound => _startRoundCommand ??
            (_startRoundCommand = new DelegateCommand(o => _model.PlayRound()));

        private void ResetCallback() {
            _model.Reset();
            OnPropertyChanged(nameof(GameOver));
        }

    }
}
