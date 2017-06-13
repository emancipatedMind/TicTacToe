namespace TicTacToeTester {
    using TicTacToe;
    public class GameContextMock : IGameContext {
        public MoveCollection Board { get; } = new MoveCollection();
        public IGameState State { get; set; }
    }
}