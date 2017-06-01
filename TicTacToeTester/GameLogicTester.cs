namespace TicTacToeTester {
    using NUnit.Framework;
    [TestFixture]
    public class GameLogicTester {

        [SetUp]
        public void SetUpMethod() {
        }

        [TearDown]
        public void TearDownMethod() {
        }

        [Test]
        public void PlayRound_MethodIsRan_EventFiredIsMoveFound() {
            var gm = new TicTacToe.GameLogic();
            bool eventFound = false;
            gm.MoveFound += (s, e) => eventFound = true;
            gm.PlayRound();
            Assert.IsTrue(eventFound);
        }

    }
}