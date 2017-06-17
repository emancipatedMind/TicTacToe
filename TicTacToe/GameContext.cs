namespace TicTacToe {
    public class GameContext : IGameContext {

        public GameContext() {
            for (int column = 0; column < 3; column++)
                for (int row = 0; row < 3; row++)
                    Board.Add(new Move(new Position(column, row)));

            ComputerPlayer = new ComputerPlayer(Board); 
        }

        public MoveCollection Board { get; } = new MoveCollection();
        public IGameState State { get; set; }
        public ComputerPlayer ComputerPlayer { get; private set; }
    }
}