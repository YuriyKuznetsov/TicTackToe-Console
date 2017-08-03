using System;



namespace TicTacToe
{

    public enum CellState
    {
        
        Player1=Players.Player1,
        Player2=Players.Player2,
        Empty = 2
    }
    public class Board:ICloneable
    {
        
        private readonly CellState[,] _board = new CellState[3, 3];

        public Board()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this._board[i, j] = CellState.Empty;
                }
            }
        }

        public Board(string board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this._board[i, j] = GetState(board[i * 3 + j ]);
                }
            }
        }
       
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    hash = hash * 3 + (int)this._board[i, j];
                }
            }

            return hash;
        }

        public bool IsFull()
        {
            for (var x = 0; x < 3; x++)
            {
                for (var y = 0; y < 3; y++)
                {
                    if (_board[x, y] == CellState.Empty)
                        return false;
                }
            }
            return true;
        }
        public object Clone()
        {
            var newBoard=new Board();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    newBoard._board[i, j] = this._board[i, j];
                }
            }
            return newBoard;
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public Board MakeNewPosition(int row, int col, Players player)
        {
            if (row < 0 || row > 2 || col < 0 || col > 2)
            {
                return null;
            }

            if (this._board[row, col] != CellState.Empty)
            {
                return null;
            }

            var newState = this.Clone() as Board;
            newState._board[row, col] = (CellState) player;
            return newState;
        }

        public bool IsWinning(Players player)
        {
            var diag1Winning = true;
            var diag2Winning = true;

            for (int i = 0; i < 3; i++)
            {
                var rowWinning = true;
                var colWinning = true;

                if (this._board[i, i] != (CellState) player)
                {
                    diag1Winning = false;
                }

                if (this._board[i, 2 - i] != (CellState) player)
                {
                    diag2Winning = false;
                }

                for (int j = 0; j < 3; j++)
                {
                    if (this._board[i, j] != (CellState) player)
                    {
                        rowWinning = false;
                    }
                    if (this._board[j, i] != (CellState) player)
                    {
                        colWinning = false;
                    }
                }

                if (rowWinning || colWinning)
                {
                    return true;
                }
            }

            return diag1Winning || diag2Winning;
        }

        public override string ToString()
        {
            return $@"{GetSymbol(this._board[0, 0])}{GetSymbol(this._board[0, 1])}{GetSymbol(this._board[0, 2])}
{GetSymbol(this._board[1, 0])}{GetSymbol(this._board[1, 1])}{GetSymbol(this._board[1, 2])}
{GetSymbol(this._board[2, 0])}{GetSymbol(this._board[2, 1])}{GetSymbol(this._board[2, 2])}
";
        }

        private static char GetSymbol(CellState cell)
        {
            if (cell == CellState.Empty)
            {
                return '.';
            }
            if (cell == CellState.Player1)
            {
                return 'X';
            }
            return 'O';
         }

        private static CellState GetState(char c)
        {
            if (c=='.')
            {
                return CellState.Empty;
            }
            if (c == 'X' )
            {
                return CellState.Player1;
            }
            return CellState.Player2;
        }
    }

}

