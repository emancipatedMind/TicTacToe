namespace TicTacToe {
    using System.Windows.Controls;
    public class Location {

        State _state = State.Open;

        public Location(Button button, int index) {
            Button = button;
            Index = index;
        }

        public object XContent { get; set; } = State.X;
        public object OContent { get; set; } = State.O;
        public object OpenContent { get; set; } = null;
        public int Index { get; private set; }
        public Button Button { get; private set; }
        public State State {
            get => _state;
            set {
                _state = value;
                Button.IsEnabled = false;
                switch(_state) {
                    case State.X:
                        Button.Content = XContent;
                        break;
                    case State.O:
                        Button.Content = OContent;
                        break;
                }
            }
        }

        public void Reset() {
            Button.IsEnabled = true;
            Button.Content = OpenContent;
            _state = State.Open;
        }

        public override string ToString() => $"[{Index}]";
        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object obj) => obj is Location && obj.GetHashCode() == GetHashCode();
    }

}