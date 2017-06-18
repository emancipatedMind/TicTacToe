namespace TicTacToe.Game {
    using System.Collections.Generic;
    public interface IGameContext {
        MoveCollection Board { get; }
        IGameState State { get; set; }
        IMoveMaker ComputerPlayer { get; }
        Judge Judge { get; }
        List<Move> MoveHistory { get; }
    }
}