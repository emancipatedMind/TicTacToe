namespace TicTacToe {
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Controls;
    public class LocationCollection : IEnumerable<Location> {
        Location[] _collection = new Location[9];

        public IEnumerator<Location> GetEnumerator() =>
            ((IEnumerable<Location>)_collection).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            _collection.GetEnumerator();

        public Location this[int index] {
            get => _collection [index];
            set {
                _collection[index] = value;
                value.Index = index;
            }
        }

        public void Reset() {
            foreach (var l in _collection)
                l.Piece = Pieces.None;
        }

        public void FreezeLocations() {
            foreach (var l in _collection)
                l.Button.IsEnabled = false;
        }

    }
}