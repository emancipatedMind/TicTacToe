namespace TicTacToe.AI {
    public class Computer {

        readonly LocationCollection _collection;

        public Computer(LocationCollection collection) {
            _collection = collection;
        }

        public void Move() {
            _collection.GetLocation(4).State = State.O;
        }
    }
}