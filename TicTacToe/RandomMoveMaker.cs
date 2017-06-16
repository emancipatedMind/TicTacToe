namespace TicTacToe {
    using System;
    using System.Linq;
    public class RandomMoveMaker : IMoveMaker {

        private MoveCollection _board;
        Random _randomizer = new Random();

        public RandomMoveMaker(MoveCollection board) {
            _board = board;
        }

        public Position MakeMove() {
            var availableMoves = _board.Where(m => m.Player == PositionBelongsTo.NoOne).ToArray();
            return availableMoves[_randomizer.Next(availableMoves.Length)].Position;
        }

    }
}
