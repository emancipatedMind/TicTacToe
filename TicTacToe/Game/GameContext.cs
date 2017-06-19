namespace TicTacToe.Game {
    using Computer;
    using System.Collections.Generic;
    using State;
    using System;
    public class GameContext : IGameContext {

        IGameState _state;

        public GameContext() {
            for (int column = 0; column < 3; column++)
                for (int row = 0; row < 3; row++) {
                    var move = new Move(new Position(column, row));
                    Board.Add(move);
                    move.PlayerChanged += (s, e) => {
                        var sender = (Move)s;
                        if (e.NewPlayer == PositionBelongsTo.NoOne)
                            MoveHistory.Remove(sender);
                        else MoveHistory.Add(sender);
                    };
                }

            ComputerPlayer = new ComputerPlayer(Board);
            Judge = new Judge(Board);

            State = new InitialGameState(this);
        }

        public MoveCollection Board { get; } = new MoveCollection();
        public IMoveMaker ComputerPlayer { get; private set; }
        public Judge Judge { get; private set; }
        public List<Move> MoveHistory { get; } = new List<Move>();
        public IGameState State {
            get => _state;
            set {
                if (_state != null) {
                    if (_state?.GetType() == value.GetType())
                        return;
                    _state.MoveFound -= _state_MoveFound;
                }
                _state = value;
                _state.MoveFound += _state_MoveFound;
            }
        }

        public event EventHandler<MoveFoundEventArgs> MoveFound;

        private void _state_MoveFound(object sender, MoveFoundEventArgs e) {
            MoveFound?.Invoke(this, e);
        }

    }
}