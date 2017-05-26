namespace TicTacToeTester {
    using NUnit.Framework;
    using TicTacToe;
    using System.Windows.Controls;
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

    }
}