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

            for (int row = 0; row < 3; row++)
                for (int column = 0; column < 3; column++) {
                    var button = new Button {
                        Margin = new Thickness(4),
                        FontSize = 60,
                        FontWeight = FontWeights.Heavy,
                    };

                    Grid.SetColumn(button, column);
                    Grid.SetRow(button, row);
                    board.Children.Add(button);
                    int index = column + row * 3;
                    GameLogic.Collection[index] = new Location(button);

                    button.CommandParameter = index;
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