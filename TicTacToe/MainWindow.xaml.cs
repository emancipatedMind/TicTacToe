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

        public MainWindow() {
            InitializeComponent();

                for (int i = 0; i < 9; i++) {
                    var button = new Button {
                        Margin = new Thickness(4),
                        FontSize = 60,
                        FontWeight = FontWeights.Heavy,
                    };

                    Grid.SetColumn(button, i % 3);
                    Grid.SetRow(button, i / 3);
                    board.Children.Add(button);
                    GameLogic.Collection[i] = new Location(button);

                    button.CommandParameter = i;
                    button.Command = new PlayerMoveCommand();
                }

        }

        private void Close_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void Reset_Click(object sender, RoutedEventArgs e) {
            GameLogic.Collection.Reset();
        }

    }
}