namespace TicTacToeTester {
    using System;
    using System.Collections.Generic;
    using TicTacToe;
    using TicTacToe.Computer;
    using TicTacToe.Game;
    using TicTacToe.Game.State;
    public class GameContextMock : IGameContext {
        public MoveCollection Board { get; } = new MoveCollection();
        public IGameState State { get; set; }
        public IMoveMaker ComputerPlayer { get; set; }
        public Judge Judge { get; private set; }
        public List<Move> MoveHistory { get; } = new List<Move>();
        public void PlayRound(Position position) { }
        public void PlayRound() { }
        public event EventHandler GameHasEndedInTie;
        public event EventHandler<GameHasBeenWonEventArgs> GameHasBeenWon;
    }
}