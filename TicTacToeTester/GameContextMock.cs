namespace TicTacToeTester {
    using System;
    using TicTacToe;
    using TicTacToe.Computer;
    using TicTacToe.Game;
    public class GameContextMock : IGameContext {
        public MoveCollection Board { get; } = new MoveCollection();
        public IMoveMaker ComputerPlayer { get; set; }
        public void PlayRound(Position position) { }
        public void PlayRound() { }
        public event EventHandler GameHasEndedInTie;
        public event EventHandler<GameHasBeenWonEventArgs> GameHasBeenWon;
    }
}