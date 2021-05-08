using System;
using System.Threading;
using System.Collections.Generic;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            StartGame();

            //thread sleeps for 1 second then screen gets cleared
            Thread.Sleep(1000); 
            Console.Clear();

            PlayGame();
            EndGame();
        }

        //splash screen
        private static void StartGame()
        {
            Console.WriteLine(" ---------------- ");
            Console.WriteLine("     HANGMAN!     ");
            Console.WriteLine(" ---------------- ");
        }

        private static void PlayGame()
        {
            //int[] positions = new int[] {}; //this is giving an exception cos maybe the size isnt defined well
            var positions = new List<int>();
            int lives = 3;
            string underscores = "";
            
            //for appending underscores
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            //instantiate random number generator
            Random rnd1 = new Random();
            int randomIndexOfArray = rnd1.Next(0, 3);
            //Console.WriteLine(randomIndexOfArray);

            //words used for hangman
            String[] wordsThatWillBeUsed = new String[3];
            wordsThatWillBeUsed[0] = "poopies";
            wordsThatWillBeUsed[1] = "kim";
            wordsThatWillBeUsed[2] = "calculator";

            //generate underlines to show length of word, underscores stored in sb
            for (int i = 0; i < wordsThatWillBeUsed[randomIndexOfArray].Length; i++)
            {
                sb.Append(underscores).Append("_ ");
            }

            //all the underscores got added into a string
            string new_underscores = sb.ToString();
            char[] charArrUnder = new_underscores.ToCharArray(); //spaces are their own element, each _ is at char[i*2]
            Console.WriteLine(charArrUnder.Length);

            //ask user for input then place the character in correct position and keep underscores
            do
            {
                string userInput = Console.ReadLine();
                char validInput= CheckUserInput(userInput);
                string validInputString = validInput.ToString();
                
                //this will refresh the screen so that you dont get unnecessary text, it will also place the valid input in place 
                if (wordsThatWillBeUsed[randomIndexOfArray].Contains(validInput))
                {
                    List<int> list = GetPositions(wordsThatWillBeUsed[randomIndexOfArray], validInputString);
                    foreach (int i in list)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            charArrUnder[i*2] = validInput;
                        }
                    }
                    string charArrUnder_String = new string(charArrUnder);
                    Console.WriteLine(charArrUnder_String);
                    Console.Clear();
                    Console.WriteLine(charArrUnder_String);
                }

            } while (Array.Exists(charArrUnder, element => element == '_'));
            
        }

        private static void EndGame()
        {
            Console.WriteLine("\n\n End!");
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
                Console.WriteLine("Please enter only one character.");
                return '_';
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
    }
}