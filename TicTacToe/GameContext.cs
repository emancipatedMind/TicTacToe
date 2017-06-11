namespace TicTacToe {
    public class GameContext : IGameContext {
        public MoveCollection Moves { get; } = new MoveCollection();
        public IGameState State { get; set; }
    }
}