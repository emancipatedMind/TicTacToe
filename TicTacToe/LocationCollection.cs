namespace TicTacToe {
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Controls;
    public class LocationCollection : IEnumerable<Location> {
        List<Location> _collection = new List<Location>();

        public void Add(Location l) => _collection.Add(l);

        public IEnumerator<Location> GetEnumerator() =>
            _collection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            _collection.GetEnumerator();

        public Location GetLocation(Button b) =>
            _collection.Where(l => l.Button == b).First();

        public Location this[int index] => _collection[index];

        public void Reset() => _collection.ForEach(l => l.Reset());
    }
}