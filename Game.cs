using System;
using System.Threading;
using System.Collections.Generic;

namespace HangMan
{
    public class Game
    {
        public Game() {}

        public void StartGame()
        {
            Console.WriteLine("  _    _          _   _  _____ __  __          _   _  ");
            Console.WriteLine(" | |  | |   /\\   | \\ | |/ ____|  \\/  |   /\\   | \\ | | ");
            Console.WriteLine(" | |__| |  /  \\  |  \\| | |  __| \\  / |  /  \\  |  \\| | ");
            Console.WriteLine(" |  __  | / /\\ \\ | . ` | | |_ | |\\/| | / /\\ \\ | . ` | ");
            Console.WriteLine(" | |  | |/ ____ \\| |\\  | |__| | |  | |/ ____ \\| |\\  | ");
            Console.WriteLine(" |_|  |_/_/    \\_\\_| \\_|\\_____|_|  |_/_/    \\_\\_| \\_| ");
            
        }

        public void Instructions()
        {
            System.Console.WriteLine("-----This set of instructions will disappear in 4 seconds-----");
            System.Console.WriteLine("1. Type 1 character then press enter.");
            System.Console.WriteLine("2. You have 6 lives, when you have no lives left the game ends.");
            System.Console.WriteLine("3. Goodluck!");
        }

        public void PlayGame()
        {
            var life = new Health { Lives = 6 };
            Draw drawings = new Draw();
            
            string underscores = "";
            
            //for appending underscores
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            //instantiate random number generator
            Random rnd1 = new Random();
            int randomIndexOfArray = rnd1.Next(0, 5);

            //words used for hangman
            String[] wordsThatWillBeUsed = new String[5];
            wordsThatWillBeUsed[0] = "replacement";
            wordsThatWillBeUsed[1] = "electronics";
            wordsThatWillBeUsed[2] = "calculator";
            wordsThatWillBeUsed[3] = "elephant";
            wordsThatWillBeUsed[4] = "sandwich";

            //generate underlines to show length of word, underscores stored in sb
            for (int i = 0; i < wordsThatWillBeUsed[randomIndexOfArray].Length; i++)
            {
                sb.Append(underscores).Append("_ ");
            }

            //all the underscores got added into a string
            string new_underscores = sb.ToString();
            System.Console.WriteLine(new_underscores);
            char[] charArrUnder = new_underscores.ToCharArray(); //spaces are their own element, each _ is at char[i*2]
            List<char> wrongLetters = new List<char>();
            string charArrUnder_String = new_underscores;

            System.Console.Write("\nLives left: ");
            System.Console.WriteLine(life.Lives);

            //ask user for input then place the character in correct position and keep underscores
            do
            {
                string userInput = Console.ReadLine();
                char validInput= CheckUserInput(userInput);
                string validInputString = validInput.ToString();

                System.Console.WriteLine(charArrUnder_String);  
                
                //easily use switch statement using numbers
                int caseNum = NumReturn(validInputString, wordsThatWillBeUsed[randomIndexOfArray]);
                
                switch (caseNum)
                {
                    //these will refresh the screen so that you dont get unnecessary text, it will also place the valid input in place and show the wrong letters
                    case 1:
                        List<int> list = GetPositions(wordsThatWillBeUsed[randomIndexOfArray], validInputString);
                        foreach (int i in list)
                        {
                            for (int j = 0; j < list.Count; j++)
                            {
                                charArrUnder[i*2] = validInput;
                            }
                        }
                        charArrUnder_String = new string(charArrUnder);
                        Console.Clear();
                        Console.WriteLine(charArrUnder_String);
                        wrongLetters.ForEach(System.Console.Write);
                        Console.Write("\nLives left: ");
                        Console.WriteLine(life.Lives);
                        break;

                    case 2:
                        life.Lives--;
                        Console.Clear();
                        wrongLetters.Add(validInput);
                        Console.WriteLine(charArrUnder_String);
                        wrongLetters.ForEach(System.Console.Write);
                        Console.Write("\nLives left: ");
                        Console.WriteLine(life.Lives);
                        break;
                }

                switch(life.Lives)
                {
                    case 0:
                        drawings.Draw1();
                        EndGameLose();
                        System.Environment.Exit(0);
                        break;
                    
                    case 1:
                        drawings.Draw2();
                        break;

                    case 2:
                        drawings.Draw3();
                        break;

                    case 3:
                        drawings.Draw4();
                        break;

                    case 4:
                        drawings.Draw5();
                        break;
                    
                    case 5:
                        drawings.Draw6();
                        break;
                    
                    case 6:
                        drawings.Draw7();
                        break;
                }
            } while (Array.Exists(charArrUnder, element => element == '_'));
        }

        public void EndGameLose()
        {
            Console.WriteLine("\nWow good job you lost!");
            Console.WriteLine("Thanks for playing though!");
            Thread.Sleep(3000); 
        }

        public void EndGameWin()
        {
            Console.WriteLine("\nYAY you won!");
            Console.WriteLine("Thanks for playing!");
            Thread.Sleep(3000); 
        }

        private static char CheckUserInput(string a) //takes string as input, if length is of 1 char then convert to char and return char
        {
            if (a.Length == 1)
            {
                char[] validInput = a.ToCharArray();
                return validInput[0];
                
            }
            else
            {
                Console.WriteLine("Please enter only one character. (wait for 1.5 seconds)");
                Thread.Sleep(1500);
                return '\\';
            }
        }

        private static List<int> GetPositions(string source, string searchString)
        {
            List<int> ret = new List<int>();
            int len = searchString.Length;
            int start = -len;
            while (true)
            {
                start = source.IndexOf(searchString, start + len);
                if (start == -1)
                {
                    break;
                }
                else
                {
                    ret.Add(start);
                }
            }
            return ret;
        }

        private static int NumReturn(string userIn, string wordToCompare)
        {
            if (wordToCompare.Contains(userIn))
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}
