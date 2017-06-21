namespace TicTacToe {
    using ToolkitNFW4.XAML;
    public class ButtonViewModel : EntityBase {

        Move _move;

        public ButtonViewModel(Move move) {
            _move = move;
            _move.PlayerChanged += (s, e) =>
                OnPropertyChanged(nameof(PositionOwner));
        }

        public Position Position => _move.Position;

        public PositionBelongsTo PositionOwner => _move.Player;

    }
}