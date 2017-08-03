namespace TicTacToe
{
    public interface IPlayer
    {
        string Name { get;}
        Board PlayMove(Board board,Players player);

    }
}