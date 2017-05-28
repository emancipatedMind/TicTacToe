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

        public static Location PlayRound(int playerMove) {
            if (Collection.Where(x => x.Piece == Pieces.None).Count() > 6)
                return GetRandomOpenLocation();

            Func<Location>[] methods = new Func<Location>[] {
                CheckIfWinningMoveAvailable,
                CheckIfOpponentHasWinningMove,
            };

            foreach(var m in methods) {
                Location l = m();
                if (l != null) return l;
            }
            return GetRandomOpenLocation();
        }

        static Location CheckIfOpponentHasWinningMove() => CheckForWinningMove(
            Collection.Where(x => x.Piece == PlayerPiece)
        );

        static Location CheckIfWinningMoveAvailable() => CheckForWinningMove(
            Collection.Where(x => x.Piece == ComputerPiece)
        );

        static Location CheckForWinningMove(IEnumerable<Location> checkLocations) {
            foreach(var l in checkLocations.Where(x => x.Index % 2 == 0)) {
                if (l.Index == 4) {
                    for (int i = 0; i < 9; i++) {
                        if (i == 4) continue;
                        Location winningSpace = Collection[8 - i];
                        bool check = checkLocations.Contains(Collection[i]);
                        if (check && winningSpace.Piece == Pieces.None)
                            return winningSpace;
                    }
                }
                else if (l.Index == 0) {
                    if (checkLocations.Contains(Collection[1]) && Collection[2].Piece == Pieces.None)
                        return Collection[2];
                    if (checkLocations.Contains(Collection[3]) && Collection[6].Piece == Pieces.None)
                        return Collection[6];
                }
                else if (l.Index == 2) {
                    if (checkLocations.Contains(Collection[1]) && Collection[0].Piece == Pieces.None)
                        return Collection[0];
                    if (checkLocations.Contains(Collection[5]) && Collection[8].Piece == Pieces.None)
                        return Collection[8];
                }
                else if (l.Index == 6) {
                    if (checkLocations.Contains(Collection[3]) && Collection[0].Piece == Pieces.None)
                        return Collection[0];
                    if (checkLocations.Contains(Collection[7]) && Collection[8].Piece == Pieces.None)
                        return Collection[8];
                }
                else if (l.Index == 8) {
                    if (checkLocations.Contains(Collection[5]) && Collection[2].Piece == Pieces.None)
                        return Collection[2];
                    if (checkLocations.Contains(Collection[7]) && Collection[6].Piece == Pieces.None)
                        return Collection[6];
                }
            }
            return null;
        }

        static Location GetRandomOpenLocation() {
            var openLocations = OpenSpaces.ToArray();
            return openLocations[rand.Next(openLocations.Length)];
        }
    }
}
