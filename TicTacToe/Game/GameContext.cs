namespace TicTacToe.Game {
    using Computer;
    using System;
    using System.Linq;
    public class GameContext : IGameContext {

        #region Fields
        WinningSetRetriever _winningSetRetriever = new WinningSetRetriever();
        #endregion

        #region Constructors
        public GameContext() {

            for (int column = 0; column < 3; column++) {
                for (int row = 0; row < 3; row++) {
                    var move = new Move(new Position(column, row));
                    move.PlayerChanged += Move_PlayerChanged;
                    Board.Add(move);
                }
            }

            ComputerPlayer = new ComputerPlayer(Board);
        }
        #endregion

        #region Events
        public event EventHandler GameHasEndedInTie;
        public event EventHandler<GameHasBeenWonEventArgs> GameHasBeenWon;
        #endregion

        #region Properties
        public MoveCollection Board { get; set; } = new MoveCollection();
        public IMoveMaker ComputerPlayer { get; set; }
        public bool GameOver { get; private set; } = false;
        #endregion

        #region Methods
        public void PlayRound(Position position) => MakeMove(position);

        public void PlayRound() => MakeMove();

        public void Reset() {
            GameOver = false;
            Board.Reset();
        }
        #endregion

        #region Support Methods
        protected void MakeMove(Position? playerMove = null) {

            if (playerMove != null)
                Board[playerMove.Value].Player = PositionBelongsTo.User;

            if (GameOver)
                return;

            Position computerChosenPosition = ComputerPlayer.MakeMove();
            Board[computerChosenPosition].Player = PositionBelongsTo.Computer;

        }

        protected void Move_PlayerChanged(object sender, PlayerChangedEventArgs e) {
            var move = (Move)sender;

            var playerPositionsQuery = Board.Where(m => m != move && m.Player == move.Player).Select(m => m.Position);
            var availableMoves = Board.Where(m => m.Player == PositionBelongsTo.NoOne);

            if (e.NewPlayer == PositionBelongsTo.NoOne || availableMoves.Count() >= 5)
                return;

            Position[] playerPositions = playerPositionsQuery.ToArray();
            Position[][] possibleWinningPositions = _winningSetRetriever.GetWinningPositions(move.Position);

            foreach (var set in possibleWinningPositions) {
                if (playerPositions.Contains(set[0]) && playerPositions.Contains(set[1])) {
                    GameOver = true;
                    GameHasBeenWon?.Invoke(this, new GameHasBeenWonEventArgs(move));
                    return;
                }
            }

            if (availableMoves.Count() == 0) {
                GameOver = true;
                GameHasEndedInTie?.Invoke(this, EventArgs.Empty);
            }

        }
        #endregion

    }
}