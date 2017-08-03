using System;


namespace TicTacToe
{
    static class TicTacToe
    {
        public static void Play(IPlayer[] players)
        {
            var moves = 0;
            Board board = new Board();

            var currentPlayer = 0;
            while (moves < 9)
            {
                Console.WriteLine(board);
                board = players[currentPlayer].PlayMove(board, (Players)currentPlayer);

                if (board.IsWinning((Players)currentPlayer))
                {
                    Console.WriteLine(board);
                    Console.WriteLine($"{players[currentPlayer].Name} is winning!");
                    return;
                }
                moves++;
                currentPlayer ^= 1;

            }
            Console.WriteLine(board);
            Console.WriteLine("Draw!");

        }
    }
}
