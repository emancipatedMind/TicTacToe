namespace TicTacToe {
    using System.Windows.Controls;
    public class Location {

        Pieces _state = Pieces.None;

        public Location(Button button) {
            Button = button;
        }

        public object XContent { get; set; } = Pieces.X;
        public object OContent { get; set; } = Pieces.O;
        public object OpenContent { get; set; } = null;
        public int Index { get; set; }
        public Button Button { get; private set; }
        public Pieces Piece {
            get => _state;
            set {
                _state = value;
                Button.IsEnabled = _state == Pieces.None;
                switch(_state) {
                    case Pieces.X:
                        Button.Content = XContent;
                        break;
                    case Pieces.O:
                        Button.Content = OContent;
                        break;
                    case Pieces.None:
                        Button.Content = OpenContent;
                        break;
                }
            }
        }

        public override string ToString() => $"[{Index}]";
        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object obj) => obj is Location && obj.GetHashCode() == GetHashCode();
    }

}