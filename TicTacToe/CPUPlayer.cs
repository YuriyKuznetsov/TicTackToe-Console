using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;


namespace TicTacToe
{
    class CPUPlayer : IPlayer
    {
        private readonly SolutionTree _solutions;
        public string Name { get;}

        public CPUPlayer(string name)
        {
            Name = name;
            _solutions = new SolutionTree();
        }
        public Board PlayMove(Board board, Players player)
        {
            var sol = _solutions.GetSolution(board);
            Console.WriteLine($"{Name}:{sol.Row+1}-{sol.Col+1}");
            return board.MakeNewPosition(sol.Row, sol.Col, player);

        }


        public override string ToString()
        {
            return "CPU Player";
        }

        private class Solution
        {
            public Solution(int row, int col, int result)
            {
                Row = row;
                Col = col;
                Result = result;
            }

            public int Row { get; }
            public int Col { get; }

            public int Result { get; }

        }
        private class SolutionTree
        {
            private readonly Dictionary<Board, Solution> _solutions = new Dictionary<Board, Solution>();

            public SolutionTree()
            {
                CreateTree(new Board(), Players.Player1, Players.Player2, 0);
            }

            public Solution GetSolution(Board board)
            {
                return _solutions[board];
            }

            private int CreateTree(Board board, Players currentPlayer, Players otherPlayer, int level)
            {
                //if (_solutions.ContainsKey(board))
                //{
                //    return _solutions[board].Result;
                //}

                Solution solution;

                var solutions = new List<Solution>();

                

                if (board.IsWinning(otherPlayer))
                {
                    int gameresult;
                    if (otherPlayer == Players.Player1)
                    {
                        gameresult = -10+level;

                    }

                    else
                    {
                        gameresult = 10-level;
                    }
                    //_solutions[board] = new Solution(-1, -1, gameresult);
                    return gameresult;
                }

                if (board.IsFull())
                {
                    return 0;
                }
                for (var x = 0; x < 3; x++)
                {
                    for (var y = 0; y < 3; y++)
                    {
                        var newBoard = board.MakeNewPosition(x, y, currentPlayer);

                        if (newBoard == null)
                        {
                            continue;
                        }

                        var result = CreateTree(newBoard, otherPlayer, currentPlayer, level + 1);

                        solutions.Add(new Solution(x, y, result));
                    }
                }

                int value;
                if (currentPlayer == Players.Player1)
                {

                    value = solutions.Min(x => x.Result);
                }
                else
                {
                    value = solutions.Max(x => x.Result);
                }
                var r=new Random();
                solutions =solutions.FindAll(s=>s.Result==value);
                solution = solutions[r.Next(solutions.Count)];
                _solutions[board] = solution;
                return solution.Result;
            }
        }
    }
}
