namespace TicTacToe.Game {
    using Computer;
    using System;
    public interface IGameContext {
        MoveCollection Board { get; }
        IMoveMaker ComputerPlayer { get; set; }
        void PlayRound(Position position);
        void PlayRound();
        event EventHandler GameHasEndedInTie;
        event EventHandler<GameHasBeenWonEventArgs> GameHasBeenWon;
    }
}