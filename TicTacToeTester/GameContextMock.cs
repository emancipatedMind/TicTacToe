namespace TicTacToeTester {
    using TicTacToe;
    public class GameContextMock : IGameContext {
        public MoveCollection Moves { get; } = new MoveCollection();
        public IGameState State { get; set; }
    }
}