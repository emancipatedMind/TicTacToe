namespace TicTacToe.Game {
    using System.Collections.Generic;
    public class GameContext : IGameContext {

        public GameContext() {
            for (int column = 0; column < 3; column++)
                for (int row = 0; row < 3; row++) {
                    var move = new Move(new Position(column, row));
                    Board.Add(move);
                    move.PlayerChanged += (s, e) => {
                        var sender = (Move)s;
                        if (e.NewPlayer == PositionBelongsTo.NoOne) {
                            MoveHistory.Remove(sender);
                        }
                        MoveHistory.Add(sender);
                    };
                }

            ComputerPlayer = new ComputerPlayer(Board);
            Judge = new Judge(Board);

        }

        public MoveCollection Board { get; } = new MoveCollection();
        public IGameState State { get; set; }
        public IMoveMaker ComputerPlayer { get; private set; }
        public Judge Judge { get; private set; }
        public List<Move> MoveHistory { get; } = new List<Move>();
    }
}