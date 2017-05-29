namespace TicTacToe {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public static class GameLogic {
        static Random rand = new Random();
        static Dictionary<int, int[][]> _winningSets = new Dictionary<int, int[][]> {
            {0, new int[][] {
                new int[] {1, 2},
                new int[] {3, 6},
                new int[] {4, 8}
            }},
            {2, new int[][] {
                new int[] {1, 0},
                new int[] {4, 6},
                new int[] {5, 8}
            }},
            {4, new int[][] {
                new int[] {0, 8},
                new int[] {1, 7},
                new int[] {2, 6},
                new int[] {3, 5}
            }},
            {6, new int[][] {
                new int[] {3, 0},
                new int[] {4, 2},
                new int[] {7, 8}
            }},
            {8, new int[][] {
                new int[] {4, 0},
                new int[] {5, 2},
                new int[] {7, 6}
            }},
        };

        public static LocationCollection Collection { get; } = new LocationCollection();
        public static Pieces PlayerPiece { get; set; } = Pieces.X;
        public static Pieces ComputerPiece => PlayerPiece == Pieces.O ? Pieces.X : Pieces.O;
        static IEnumerable<Location> OpenSpaces =>
            Collection.Where(x => x.Piece == Pieces.None);

        public static event EventHandler GameEndsWithNoWinner;
        public static event EventHandler<GameHasBeenWonEventArgs> GameHasBeenWon;

        public static void PlayRound(int playerMove) {
            try {

                try {
                    Location playerChoice = Collection[playerMove];
                    playerChoice.Piece = PlayerPiece;
                    CheckIfLocationWins(PlayerPiece);
                }
                catch(IndexOutOfRangeException) { }

                if (Collection.Where(x => x.Piece == Pieces.None).Count() > 6) {
                    GetRandomOpenLocation().Piece = ComputerPiece;
                    return;
                }
                else if (Collection.Where(x => x.Piece == Pieces.None).Count() == 0) {
                    GameEndsWithNoWinner?.Invoke(typeof(GameLogic), EventArgs.Empty);
                    return;
                }

                try {
                    CheckIfWinningMoveAvailable();
                    CheckIfOpponentHasWinningMove();
                    GetRandomOpenLocation().Piece = ComputerPiece;
                }
                catch(MoveFoundException ex) {
                    ex.Move.Piece = ComputerPiece;
                }
                catch(WinningMoveFoundException ex) {
                    ex.Move.Piece = ComputerPiece;
                    CheckIfLocationWins(ComputerPiece);
                }

            }
            catch(GameWonException ex) {
                Collection.FreezeLocations();
                GameHasBeenWon?.Invoke(typeof(GameLogic), new GameHasBeenWonEventArgs(ex.WinningSet, ex.Winner));
            }
        }

        private static void CheckIfLocationWins(Pieces movingPlayer) {
            var moves = Collection.Where(x => x.Index % 2 == 0 && x.Piece == movingPlayer);
            foreach(var l in moves) {
                CheckIfSquareIsPartOfWinningSet(l.Index);
            }
        }

        private static void CheckIfSquareIsPartOfWinningSet(int index) {
            Pieces p = Collection[index].Piece;
            foreach (var set in _winningSets[index])
                if (Collection[set[0]].Piece == p && Collection[set[1]].Piece == p)
                    throw new GameWonException(
                    Collection
                        .Where(x => x.Index == set[0] || x.Index == set[1] || x.Index == index)
                        .OrderBy(x => x.Index)
                        .ToArray(),
                        p
                    );
        }

        static void CheckIfOpponentHasWinningMove() => CheckForWinningMove(
            Collection.Where(x => x.Piece == PlayerPiece)
        );

        static void CheckIfWinningMoveAvailable() {
            try {
                CheckForWinningMove(Collection.Where(x => x.Piece == ComputerPiece));
            }
            catch (MoveFoundException ex) {
                throw new WinningMoveFoundException(ex.Move);
            }
        }

        static void CheckForWinningMove(IEnumerable<Location> checkLocations) {
            foreach(var l in checkLocations.Where(x => x.Index % 2 == 0)) {
                foreach(var s in _winningSets[l.Index] ) {
                    CheckSquaresForMove(checkLocations, s[0], s[1]);
                    CheckSquaresForMove(checkLocations, s[1], s[0]);
                }
            }
        }

        static void CheckSquaresForMove(IEnumerable<Location> checkLocations,int square1, int square2) {
            if (checkLocations.Contains(Collection[square1]) && Collection[square2].Piece == Pieces.None)
                throw new MoveFoundException(Collection[square2]);
        }

        static Location GetRandomOpenLocation() {
            var openLocations = OpenSpaces.ToArray();
            return openLocations[rand.Next(openLocations.Length)];
        }
    }
}
