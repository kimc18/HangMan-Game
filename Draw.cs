using System;

namespace HangMan
{
    public class Draw
    {
        public Draw() {}

        public void Draw7()
        {
            System.Console.WriteLine(" +---+ ");
            System.Console.WriteLine(" |   |");
            System.Console.WriteLine("     |");
            System.Console.WriteLine("     |");
            System.Console.WriteLine("     |");
            System.Console.WriteLine("     |");
            System.Console.WriteLine("========");
        }

        public void Draw6()
        {
            System.Console.WriteLine(" +---+ ");
            System.Console.WriteLine(" |   |");
            System.Console.WriteLine(" o   |");
            System.Console.WriteLine("     |");
            System.Console.WriteLine("     |");
            System.Console.WriteLine("     |");
            System.Console.WriteLine("========");
        }

        public void Draw5()
        {
            System.Console.WriteLine(" +---+ ");
            System.Console.WriteLine(" |   |");
            System.Console.WriteLine(" o   |");
            System.Console.WriteLine(" |   |");
            System.Console.WriteLine("     |");
            System.Console.WriteLine("     |");
            System.Console.WriteLine("========");
        }

        public void Draw4()
        {
            System.Console.WriteLine(" +---+ ");
            System.Console.WriteLine(" |   |");
            System.Console.WriteLine(" o   |");
            System.Console.WriteLine("/|   |");
            System.Console.WriteLine("     |");
            System.Console.WriteLine("     |");
            System.Console.WriteLine("========");
        }

        public void Draw3()
        {
            System.Console.WriteLine(" +---+ ");
            System.Console.WriteLine(" |   |");
            System.Console.WriteLine(" o   |");
            System.Console.WriteLine("/|\\  |");
            System.Console.WriteLine("     |");
            System.Console.WriteLine("     |");
            System.Console.WriteLine("========");
        }

        public void Draw2()
        {
            System.Console.WriteLine(" +---+ ");
            System.Console.WriteLine(" |   |");
            System.Console.WriteLine(" o   |");
            System.Console.WriteLine("/|\\  |");
            System.Console.WriteLine("/    |");
            System.Console.WriteLine("     |");
            System.Console.WriteLine("========");
        }

        public void Draw1()
        {
            System.Console.WriteLine(" +---+ ");
            System.Console.WriteLine(" |   |");
            System.Console.WriteLine(" o   |");
            System.Console.WriteLine("/|\\  |");
            System.Console.WriteLine("/ \\  |");
            System.Console.WriteLine("     |");
            System.Console.WriteLine("========");
        }
    }
}
