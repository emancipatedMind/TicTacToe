using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        double _gamesPlayed = 0.0;
        double _gamesWon = 0.0;
        bool _computerGoesFirst = true;

        public MainWindow() {
            InitializeComponent();

            for (int i = 0; i < 9; i++) {
                var button = new Button {
                    Margin = new Thickness(4),
                    FontSize = 40,
                    FontWeight = FontWeights.Heavy,
                };

                Grid.SetColumn(button, i % 3);
                Grid.SetRow(button, i / 3);
                board.Children.Add(button);
                var buttonAdapter = new ButtonAdapter(button);
                GameLogic.Collection[i] = new Location(buttonAdapter);

                button.CommandParameter = i;
                button.Command = new PlayerMoveCommand();
            }

            GameLogic.GameEndsWithNoWinner += GameLogic_GameEndsWithNoWinner;
            GameLogic.GameHasBeenWon += GameLogic_GameHasBeenWon;
        }

        private void GameLogic_GameHasBeenWon(object sender, GameHasBeenWonEventArgs e) {
            string winner = "";
            if (e.WinningPiece == GameLogic.PlayerPiece) {
                _gamesWon++;
                winner = "You got me, but I'm confident about the next.\n\nWill you give me a rematch?";
            }
            else {
                winner = "Ha... Gotcha...\n\nBetter luck next time!";
            }
            winP.Content = (_gamesWon * 100 / ++_gamesPlayed).ToString("F2");
            _computerGoesFirst = !_computerGoesFirst;
            MessageBox.Show(winner);
        }

        private void GameLogic_GameEndsWithNoWinner(object sender, EventArgs e) {
            winP.Content = (_gamesWon * 100 / ++_gamesPlayed).ToString("F2");
            _computerGoesFirst = !_computerGoesFirst;
            MessageBox.Show("Game Tied!");
        }

        private void Close_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void Reset_Click(object sender, RoutedEventArgs e) {
            GameLogic.Collection.Reset();
            if (_computerGoesFirst) GameLogic.PlayRound(-1);
        }

    }
}