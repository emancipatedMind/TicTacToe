namespace TicTacToe {
    using System.Collections;
    using System.Collections.Generic;
    public class MoveCollection : IEnumerable<Move> {

        List<Move> _moves = new List<Move>();

        public MoveCollection() {
            for (int column = 0; column < 3; column++)
                for (int row = 0; row < 3; row++)
                    _moves.Add(new Move(new Position(column, row)));
        }

        public void Reset() {
            _moves.ForEach(m => m.Player = PositionBelongsTo.NoOne);
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            _moves.GetEnumerator();

        public IEnumerator<Move> GetEnumerator() =>
            _moves.GetEnumerator();

        public Move this[int index] => _moves[index];
    }
}