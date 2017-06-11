namespace TicTacToeTester {
    using NUnit.Framework;
    using TicTacToe;
    [TestFixture] 
    public class InitialStateTester {

        [Test] 
        public void Handle_MoveCollectionContainsNoMovesByEitherPlayer_MoveFoundEventFiresWithRandomMove() {
            var contextStub = new GameContextMock();

            for (int column = 0; column < 3; column++)
                for (int row = 0; row < 3; row++)
                    contextStub.Moves.Add(new Move(new Position(column, row))); 

            Position position = new Position();
            bool eventFired = false;

            var initialState = new InitialState(contextStub);
            initialState.MoveFound += (s, e) => {
                eventFired = true;
                position = e.Position;
            };
            initialState.Handle();

            Assert.IsTrue(eventFired);
            Assert.IsTrue(position.Column >= 0 && position.Column < 3);
            Assert.IsTrue(position.Row >= 0 && position.Row < 3);
        }
    }

}