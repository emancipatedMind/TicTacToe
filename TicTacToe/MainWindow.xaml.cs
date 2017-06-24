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

            var viewModel = (GameLogic) Application.Current.Resources["viewModel"];

            for (int column = 0; column < 3; column++) {
                for (int row = 0; row < 3; row++) {
                    var button = new Button();
                    Grid.SetColumn(button, column);
                    Grid.SetRow(button, row);
                    var position = new Position(column, row);
                    button.SetBinding(DataContextProperty, new Binding { Source = viewModel.ButtonViewModelList.First(o => o.Position == position) });
                    button.CommandParameter = position;
                    button.Command = viewModel.PlayRound;
                    board.Children.Add(button);
                }
            }

            viewModel.GameHasEndedInTie += (s, e) => {
                board.Dispatcher.BeginInvoke(new Action(() => {
                    MessageBox.Show("Tie. Reset application to play another game.");
                }));
            };

        }

        private void Close_Click(object sender, RoutedEventArgs e) {
            Close();
        }

    }
}