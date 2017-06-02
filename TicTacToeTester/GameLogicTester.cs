namespace TicTacToeTester {
    using NUnit.Framework;
    using TicTacToe;
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
            var gm = new GameLogic();
            bool eventFound = false;
            gm.MoveFound += (s, e) => eventFound = true;
            gm.PlayRound();
            Assert.IsTrue(eventFound);
        }

        [Test]
        public void PlayRound_UserSubmitsPosition_EventFiredIsMoveFound() {
            var position = new Position(0, 0);
            var gm = new GameLogic();
            bool eventFound = false;
            gm.MoveFound += (s, e) => eventFound = true;
            gm.PlayRound(position);
            Assert.IsTrue(eventFound);
        }

    }
}