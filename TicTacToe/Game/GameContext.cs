namespace TicTacToe.Game {
    using Computer;
    using System;
    public class GameContext : IGameContext {
        public MoveCollection Board => throw new NotImplementedException();
        public IMoveMaker ComputerPlayer { get; set; }
        public event EventHandler GameHasEndedInTie;
        public event EventHandler<GameHasBeenWonEventArgs> GameHasBeenWon;
        public void PlayRound(Position position) { }
        public void PlayRound() { }
    }
}