namespace TicTacToe {
    using System.Windows.Controls;
    public class Location {

        State _state = State.Open;

        public Location(Button button,int column, int row) {
            Button = button;
            Column = column;
            Row = row;
        }

        public int Column { get; private set; }
        public int Row { get; private set; }
        public Button Button { get; private set; }
        public State State {
            get => _state;
            set {
                if (_state != State.Open) return;
                _state = value;
                Button.Content = _state;
            }
        }

        public void Reset() {
            Button.Content = null;
            _state = State.Open;
        }

        public override string ToString() => $"[{Column},{Row}]";
        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object obj) => obj is Location && obj.GetHashCode() == GetHashCode();
    }

}