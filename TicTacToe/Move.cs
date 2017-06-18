namespace TicTacToe {
    using System;
    public class Move {

        private PositionBelongsTo _player;

        public Move(Position position) : this(PositionBelongsTo.NoOne, position) { }

        public Move(PositionBelongsTo player, Position position) {
            Player = player;
            Position = position;
        }

        public Position Position { get; private set; }

        public PositionBelongsTo Player {
            get => _player;
            set {
                if (value == _player) return;
                PositionBelongsTo oldValue = _player;
                _player = value;
                PlayerChanged?.Invoke(this, new PlayerChangedEventArgs(_player, oldValue));
            }
        }

        public event EventHandler<PlayerChangedEventArgs> PlayerChanged;

        public override string ToString() => $"Position Belongs To:{Player};{nameof(Position)}:{Position}";
        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object obj) => obj is Move && GetHashCode() == obj.GetHashCode();
    }
}