using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {
        static string usersName = string.Empty;
        static string[] possibleWords = {"TURTLE","DATSUN","SPACEDONKEY","NICKLEBACK","DOGS","DOLPHINS",};
        static Random rng = new Random();
        static int counterLives = 8;
        static string usersGuess = string.Empty;
        static bool playing = true;
        static string hiddenWord = string.Empty;
        static string actualWord = string.Empty;
        static void Main(string[] args)
        {
            StartScreen();
            while (playing == true)
            {
                if (counterLives != 0)
                {
                    WordHidden();
                    Console.ReadKey();  
                }
                else
                {

                }

            }
            Console.ReadKey();
        }
        static void StartScreen()
        {
            
            Console.WriteLine("                 Welcome to Hangman what is your name user?                     ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("                                     ");
            usersName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("                               Welcome {0}!                                     ",usersName);
            Console.WriteLine("");
            Console.WriteLine("          You have 8 chances to guess the word using either a letter            ");
            Console.WriteLine("                        or by trying to guess the word                          ");
            Console.WriteLine("                         Press any key to continue...                           ");
            Console.ReadKey();
            Console.Clear();
        }
        static bool ValidateUserInput(string userInput)
        {
            userInput.ToUpper();
            if ("ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(userInput))
            {
                userInput = usersGuess;
                return true;
            }
            return false;
        }
        public static void WordHidden()
        {
            int randomWordInt = rng.Next(0, possibleWords.Length);
            actualWord = possibleWords[randomWordInt];
            for (int i = 0; i < actualWord.Length; i++)
            {
                hiddenWord += "_";
            }
            Console.WriteLine(hiddenWord);
        }
        static void ChangeHiddenWord(string guess)
        {
            if (actualWord.Contains(guess))
            {
                if (guess.Length == 1)
	            {
                    char tempLetter = guess[0];
                    for (int i = 0; i < actualWord.Length; i++)
                    {
                        if (actualWord[i] == tempLetter)
                        {
                            hiddenWord.Replace('_',actualWord[i] );
                        }
                    }
                }
            }
        }
    }   
}
