namespace TicTacToe.Game.Computer {
    public class WinningSetRetriever {
        public Position[][] GetWinningPositions(Position position) {
            if (position == new Position(2, 1))
                return new Position[][] {
                    new Position[] {
                        new Position(2,0),
                        new Position(2,2),
                    },
                    new Position[] {
                        new Position(1,1),
                        new Position(0,1),
                    }
                };
            else if (position == new Position(0, 1))
                return new Position[][] {
                    new Position[] {
                        new Position(0,0),
                        new Position(0,2),
                    },
                    new Position[] {
                        new Position(1,1),
                        new Position(2,1),
                    }
                };
            else if (position == new Position(1, 2))
                return new Position[][] {
                    new Position[] {
                        new Position(0,2),
                        new Position(2,2),
                    },
                    new Position[] {
                        new Position(1,1),
                        new Position(1,0),
                    }
                };
            else if (position == new Position(1, 0))
                return new Position[][] {
                    new Position[] {
                        new Position(0,0),
                        new Position(2,0),
                    },
                    new Position[] {
                        new Position(1,1),
                        new Position(1,2),
                    }
                };
            else if (position == new Position(0, 0))
                return new Position[][] {
                    new Position[] {
                        new Position(1,0),
                        new Position(2,0),
                    },
                    new Position[] {
                        new Position(0,1),
                        new Position(0,2),
                    },
                    new Position[] {
                        new Position(1,1),
                        new Position(2,2),
                    }
                };
            else if (position == new Position(0, 2))
                return new Position[][] {
                    new Position[] {
                        new Position(1,2),
                        new Position(2,2),
                    },
                    new Position[] {
                        new Position(0,1),
                        new Position(0,0),
                    },
                    new Position[] {
                        new Position(1,1),
                        new Position(2,0),
                    }
                };
            else if (position == new Position(2, 0))
                return new Position[][] {
                    new Position[] {
                        new Position(0,0),
                        new Position(1,0),
                    },
                    new Position[] {
                        new Position(2,1),
                        new Position(2,2),
                    },
                    new Position[] {
                        new Position(1,1),
                        new Position(0,2),
                    }
                };
            else if (position == new Position(2, 2))
                return new Position[][] {
                    new Position[] {
                        new Position(0,2),
                        new Position(1,2),
                    },
                    new Position[] {
                        new Position(2,1),
                        new Position(2,0),
                    },
                    new Position[] {
                        new Position(1,1),
                        new Position(0,0),
                    }
                };
            else if (position == new Position(1, 1))
                return new Position[][] {
                    new Position[] {
                        new Position(0,0),
                        new Position(2,2),
                    },
                    new Position[] {
                        new Position(0,2),
                        new Position(2,0),
                    },
                    new Position[] {
                        new Position(1,0),
                        new Position(1,2),
                    },
                    new Position[] {
                        new Position(0,1),
                        new Position(2,1),
                    }
                };
            else throw new InvalidPositionException($"Illegal position. {position.ToString()}");
        }
    }
}