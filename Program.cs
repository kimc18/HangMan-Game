using System;
using System.Threading;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.StartGame();

            //thread sleeps for 1 second then screen gets cleared
            Thread.Sleep(1000); 
            Console.Clear();

            game.Instructions();
            Thread.Sleep(4000); 
            Console.Clear();

            game.PlayGame();
            game.EndGameWin();
        }
    }
}