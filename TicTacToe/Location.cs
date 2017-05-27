namespace TicTacToe {
    using System.Windows.Controls;
    public class Location {

        Pieces _state = Pieces.None;
        Button _button;

        public Location(Button button) {
            _button = button;
        }

        public object XContent { get; set; } = Pieces.X;
        public object OContent { get; set; } = Pieces.O;
        public object OpenContent { get; set; } = null;
        public int Index { get; set; }
        public Pieces Piece {
            get => _state;
            set {
                _state = value;
                _button.IsEnabled = _state == Pieces.None;
                switch(_state) {
                    case Pieces.X:
                        _button.Content = XContent;
                        break;
                    case Pieces.O:
                        _button.Content = OContent;
                        break;
                    case Pieces.None:
                        _button.Content = OpenContent;
                        break;
                }
            }
        }

        public override string ToString() => $"[{Index}]";
        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object obj) => obj is Location && obj.GetHashCode() == GetHashCode();
    }

}