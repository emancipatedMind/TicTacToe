namespace TicTacToeTester {
    using NUnit.Framework;
    using System.Windows.Controls;
    using TicTacToe;
    using TicTacToe.AI;
    [TestFixture]
    public class ComputerTester {

        LocationCollection _collection = new LocationCollection();

        [SetUp]
        public void SetUpMethod() {
            for (int i = 0; i < 9; i++) _collection.Add(new Location(new Button(), i));
        }

        [TearDown]
        public void TearDownMethod() {
            _collection.Reset();
        }

        [Test]
        public void Move_PlayerSelectsPosition0AsFirstMove_ComputerShouldSelectPosition4() {
            var computer = new Computer(_collection);
            int indexSelectedByPlayer = 0;
            Location ln = _collection.GetLocation(indexSelectedByPlayer);
            ln.State = State.X;
            computer.Move();
            for (int i = 0; i < 9; i++) {
                if (indexSelectedByPlayer == i) continue;
                State expectedState = i == 4 ? State.O : State.Open;
                Assert.AreEqual(expectedState, _collection.GetLocation(i).State);
            }
        }
    }
}