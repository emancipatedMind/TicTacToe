﻿namespace TicTacToe {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class GameLogic {

        private static Random _rdm = new Random();

        private List<Move> _moves = new List<Move>();
        private WinningSetRetriever _winningSetRetriever = new WinningSetRetriever();

        public event EventHandler<MoveFoundEventArgs> MoveFound;
        public event EventHandler GameHasEndedInTie;
        public event EventHandler GameHasBeenWon;

        public void PlayRound(Position position) {
            _moves.Add(new Move(PositionBelongsTo.User, position));
            ProcessRound();
        }

        public void PlayRound() =>
            ProcessRound();

        public void LoadGame(IEnumerable<Move> moves) {
            _moves.Clear();
            _moves.AddRange(moves);
        }

        private void ProcessRound() {
            try {

                if (_moves.Count == 0) {
                    var randomMove = new Position(_rdm.Next(2), _rdm.Next(2));
                    AddNewtoMovesAndFireMoveFoundEvent(randomMove);
                    return;
                }

                var lastMoveByUser = _moves.Where(x => x.Player == PositionBelongsTo.User).Last();
                CheckToSeeIfMoveWonGame(lastMoveByUser);

                CheckToSeeIfGameHasEndedInTie();

                AddNewtoMovesAndFireMoveFoundEvent(new Position(2,0));
                CheckToSeeIfGameHasEndedInTie();
            }
            catch (GameHasBeenWonException ex) {
                GameHasBeenWon?.Invoke(this, new GameHasBeenWonEventArgs(ex.WinningMove));
            }
            catch (GameHasEndedInTieException) {
                GameHasEndedInTie?.Invoke(this, EventArgs.Empty);
            }

        }

        private void CheckToSeeIfGameHasEndedInTie() {
            if (_moves.Count > 8)
                throw new GameHasEndedInTieException();
        }

        private void CheckToSeeIfMoveWonGame(Move move) {
            Position[][] winningMoves = _winningSetRetriever.GetWinningPositions(move.Position);
            for (int i = 0; i < winningMoves.Length; i++) {
                var gameWinningCondition = from m in _moves
                                           where m.Player == move.Player
                                           where m.Position == winningMoves[i][0] ||
                                           m.Position == winningMoves[i][1]
                                           select m;
                if (gameWinningCondition.Count() == 2)
                    throw new GameHasBeenWonException(move);
            }
        }

        private void AddNewtoMovesAndFireMoveFoundEvent(Position position) {
            _moves.Add(new Move(PositionBelongsTo.Computer, position));
            MoveFound?.Invoke(this, new MoveFoundEventArgs(position));
        }

    }
}