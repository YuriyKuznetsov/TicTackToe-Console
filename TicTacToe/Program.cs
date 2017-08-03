using System;

namespace TicTacToe
{
    public enum Players
    {
        Player1 = 0,
        Player2 = 1
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cpu1 = new CPUPlayer("CPU1");
            var cpu2 = new CPUPlayer("CPU2");
            var human = new ConsolePlayer("Human");
            //TicTacToe.Play(new IPlayer[] { human, cpu1 });
           // TicTacToe.Play(new IPlayer[] { cpu1, human });
          TicTacToe.Play(new IPlayer[] { cpu1, cpu2 });
            Console.ReadLine();
            
            //For Testing
            //var testBoard = "O...XX...";
            //var solution = s.GetSolution(new Board(testBoard));
        }
    }
}
