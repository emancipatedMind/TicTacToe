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

        [Test]
        public void PlayRound_UserSubmitsLastPosition_EventFiredIsGameHasEndedInTie() {
            var partialGame = new Move[] {
                new Move(PlayerIs.User, new Position(1, 1)),
                new Move(PlayerIs.Computer, new Position(0, 2)),
                new Move(PlayerIs.User, new Position(1, 0)),
                new Move(PlayerIs.Computer, new Position(1, 2)),
                new Move(PlayerIs.User, new Position(2, 2)),
                new Move(PlayerIs.Computer, new Position(0, 0)),
                new Move(PlayerIs.User, new Position(0, 1)),
                new Move(PlayerIs.Computer, new Position(2, 1)),
            };
            var position = new Position(2, 0);
            var gm = new GameLogic();
            bool eventFound = false;
            gm.GameHasEndedInTie += (s, e) => eventFound = true;
            gm.LoadGame(partialGame);
            gm.PlayRound(position);
            Assert.IsTrue(eventFound);
        }

        [Test]
        public void PlayRound_ComputerSubmitsLastPosition_EventFiredIsMoveFoundAndThenGameHasEndedInTie() {
            var partialGame = new Move[] {
                new Move(PlayerIs.Computer, new Position(1, 1)),
                new Move(PlayerIs.User, new Position(0, 2)),
                new Move(PlayerIs.Computer, new Position(1, 0)),
                new Move(PlayerIs.User, new Position(1, 2)),
                new Move(PlayerIs.Computer, new Position(2, 2)),
                new Move(PlayerIs.User, new Position(0, 0)),
                new Move(PlayerIs.Computer, new Position(0, 1)),
            };
            var position = new Position(2, 1);
            var gm = new GameLogic();
            bool eventOneFound = false;
            bool eventTwoFound = false;
            gm.MoveFound += (s, e) => eventOneFound = true;
            gm.GameHasEndedInTie += (s, e) => eventTwoFound = true;
            gm.LoadGame(partialGame);
            gm.PlayRound(position);
            Assert.IsTrue(eventOneFound && eventTwoFound);
        }

        [Test]
        public void PlayRound_UserSubmitsPositionThatThreatensToEndGame_MoveFoundEventContainsPositionToBlock() {
            var gm = new GameLogic();
            var partialGame = new Move[] {
                new Move(PlayerIs.User, new Position(0, 0)),
                new Move(PlayerIs.Computer, new Position(1, 2)),
            };
            var position = new Position(1, 0);
            var expectedPosition = new Position(2, 0);
            var positionChosen = new Position();
            gm.MoveFound += (s, e) => positionChosen = e.Position;
            gm.LoadGame(partialGame);
            gm.PlayRound(position);
            Assert.AreEqual(expectedPosition, positionChosen);
        }

    }
}