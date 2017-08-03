using System;
using System.Linq;

namespace TicTacToe
{
    class ConsolePlayer:IPlayer
    {
        public string Name { get; set; }
        

        public ConsolePlayer(string name)
        {
            Name = name;
        }
        public Board PlayMove(Board board, Players player)
        {
            Board newBoard;
            do
            {
                Console.Write($"{Name}: Make move (Row,Col)=");
                var moves = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

               newBoard = board.MakeNewPosition(moves[0]-1, moves[1]-1, player);
            } while (newBoard==null);

            return newBoard;


        }
        public override string ToString()
        {
            return "Console Player";
        }
    }
}
