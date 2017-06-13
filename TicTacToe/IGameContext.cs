namespace TicTacToe {
    public interface IGameContext {
        MoveCollection Board { get; }
        IGameState State { get; set; }
    }
}