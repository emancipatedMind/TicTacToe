﻿namespace TicTacToe.Game.Computer {
    public class InvalidPositionException : System.ApplicationException {
        public InvalidPositionException(string message) : base(message) { }
    }
}