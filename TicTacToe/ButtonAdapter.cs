namespace TicTacToe {
    using System;
    using System.Windows.Controls;
    public class ButtonAdapter : IEnablableContentSetter {

        Button _button;

        public ButtonAdapter(Button button) {
            _button = button;
        }

        public bool IsEnabled { get => _button.IsEnabled; set => _button.IsEnabled = value; }
        public object Content { set => _button.Content = value; }
    }
}