namespace TicTacToe {
    public class Location {

        Pieces _state = Pieces.None;

        public Location(IEnablableContentSetter contentSetter) {
            Content = contentSetter;
        }

        public object XContent { get; set; } = Pieces.X;
        public object OContent { get; set; } = Pieces.O;
        public object OpenContent { get; set; } = null;
        public IEnablableContentSetter Content { get; private set; }
        public int Index { get; set; }
        public Pieces Piece {
            get => _state;
            set {
                _state = value;
                Content.IsEnabled = _state == Pieces.None;
                switch(_state) {
                    case Pieces.X:
                        Content.Content = XContent;
                        break;
                    case Pieces.O:
                        Content.Content = OContent;
                        break;
                    case Pieces.None:
                        Content.Content = OpenContent;
                        break;
                }
            }
        }

        public override string ToString() => $"[{Index}]";
        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object obj) => obj is Location && obj.GetHashCode() == GetHashCode();
    }

}