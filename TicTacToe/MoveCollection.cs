namespace TicTacToe {
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    public class MoveCollection : IEnumerable<Move> {

        List<Move> _moves = new List<Move>();

        public void Add(Move moveToAdd) => _moves.Add(moveToAdd);
        public void Reset() => _moves.ForEach(m => m.Player = PositionBelongsTo.NoOne);
        IEnumerator IEnumerable.GetEnumerator() => _moves.GetEnumerator();
        public IEnumerator<Move> GetEnumerator() => _moves.GetEnumerator();
        public Move this[int index] => _moves[index];
        public Move this[Position position] => _moves.Where(m => m.Position == position).First();
    }
}