namespace TicTacToeTester {
    using System.Collections.Generic;
    using TicTacToe;
    public class GameContextMock : IGameContext {
        public MoveCollection Board { get; } = new MoveCollection();
        public IGameState State { get; set; }
        public IMoveMaker ComputerPlayer { get; set; }
        public Judge Judge { get; private set; }
        public List<Move> MoveHistory { get; } = new List<Move>();
    }
}