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
        [Apartment(System.Threading.ApartmentState.STA)]
        public void Move_PlayerDoesNotSelectPosition4AsFirstMove_ComputerShouldSelectPosition4() {
            for (int i = 0; i < 9; i++) {
                if (i == 4) continue;
                var computer = new Computer(_collection);
                int indexSelectedByPlayer = i;
                Location ln = _collection.GetLocation(indexSelectedByPlayer);
                ln.State = State.X;
                computer.Move();
                for (int j = 0; j < 9; j++) {
                    if (indexSelectedByPlayer == j) continue;
                    State expectedState = j == 4 ? State.O : State.Open;
                    Assert.AreEqual(expectedState, _collection.GetLocation(j).State);
                }
                _collection.Reset();
            }
        }

    }
}