namespace TicTacToe {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class GameLogic {
        static Random rand = new Random();

        public static LocationCollection Collection { get; } = new LocationCollection();
        public static Pieces ComputerPiece { get; set; } = Pieces.O;
        public static Pieces PlayerPiece => ComputerPiece == Pieces.O ? Pieces.X : Pieces.O;
        static IEnumerable<Location> OpenSpaces =>
            Collection.Where(x => x.Piece == Pieces.None);


        public static Location Move() {
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
                        Location winningSpace = Collection.GetLocation(8 - i);
                        bool check = checkLocations.Contains(Collection.GetLocation(i));
                        if (check && winningSpace.Piece == Pieces.None)
                            return winningSpace;
                    }
                }
                else if (l.Index == 0) {
                    if (checkLocations.Contains(Collection.GetLocation(1)) && Collection.GetLocation(2).Piece == Pieces.None)
                        return Collection.GetLocation(2);
                    if (checkLocations.Contains(Collection.GetLocation(3)) && Collection.GetLocation(6).Piece == Pieces.None)
                        return Collection.GetLocation(6);
                }
                else if (l.Index == 2) {
                    if (checkLocations.Contains(Collection.GetLocation(1)) && Collection.GetLocation(0).Piece == Pieces.None)
                        return Collection.GetLocation(0);
                    if (checkLocations.Contains(Collection.GetLocation(5)) && Collection.GetLocation(8).Piece == Pieces.None)
                        return Collection.GetLocation(8);
                }
                else if (l.Index == 6) {
                    if (checkLocations.Contains(Collection.GetLocation(3)) && Collection.GetLocation(0).Piece == Pieces.None)
                        return Collection.GetLocation(0);
                    if (checkLocations.Contains(Collection.GetLocation(7)) && Collection.GetLocation(8).Piece == Pieces.None)
                        return Collection.GetLocation(8);
                }
                else if (l.Index == 8) {
                    if (checkLocations.Contains(Collection.GetLocation(5)) && Collection.GetLocation(2).Piece == Pieces.None)
                        return Collection.GetLocation(2);
                    if (checkLocations.Contains(Collection.GetLocation(7)) && Collection.GetLocation(6).Piece == Pieces.None)
                        return Collection.GetLocation(6);
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
