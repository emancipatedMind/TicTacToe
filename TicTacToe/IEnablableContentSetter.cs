namespace TicTacToe {
    public interface IEnablableContentSetter {
        bool IsEnabled { get; set; }
        object Content { set; }
    }
}