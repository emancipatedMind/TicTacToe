namespace TicTacToe.Game {
    using Computer;
    using State;
    using System;
    using System.Collections.Generic;
    public interface IGameContext {
        MoveCollection Board { get; }
        IGameState State { get; set; }
        IMoveMaker ComputerPlayer { get; }
        Judge Judge { get; }
        List<Move> MoveHistory { get; }
        void PlayRound(Position position);
        void PlayRound();
        event EventHandler GameHasEndedInTie;
        event EventHandler<GameHasBeenWonEventArgs> GameHasBeenWon;
    }
}