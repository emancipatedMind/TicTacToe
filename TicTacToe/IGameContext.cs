namespace TicTacToe {
    public interface IGameContext {
        MoveCollection Moves { get; }
        IGameState State { get; set; }
    }
}