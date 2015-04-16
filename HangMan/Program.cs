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
        public static List<string> hiddenWord = new List<string> {};
        static string actualWord = string.Empty;
        static string tempHiddenWord = string.Empty;
        static bool changeHiddenWordBool = true;
        static string previousGuesses = string.Empty;
        static void Main(string[] args)
        {
            StartScreen();
            WordHidden();
            Console.WriteLine(tempHiddenWord);
            while (playing == true)
            {

                Console.WriteLine("You have {0} lives left", counterLives);
                string userUnvalidated = Console.ReadLine();
                if (ValidateUserInput(userUnvalidated))
                {
                    if (counterLives != 0)
                    {

                            if (ChangeHiddenWord(usersGuess) == true)
                            {
                                Console.Clear();
                                Console.WriteLine(tempHiddenWord);
                                Console.WriteLine("");
                                Console.Write("Guesses: ");
                                IncrementGuessString(usersGuess);
                            }
                            else
                            {
                                
                            }
                    }
                    else
                    {
                        Console.WriteLine("You have lost the game");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Response");
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
            if ("ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(userInput.ToUpper()))
            {
                usersGuess = userInput;
                return true;
            }
            else if (userInput.ToUpper() == actualWord)
            {
                usersGuess = userInput;
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
                hiddenWord.Add("_");
            }
            tempHiddenWord = string.Join(" ", hiddenWord);
        }

        static void IncrementGuessString(string letterGuessed)
        {
            previousGuesses += letterGuessed + " ";
            Console.WriteLine(previousGuesses);
        }
        static bool ChangeHiddenWord(string guess)
        {

            if (actualWord.Contains(usersGuess.ToUpper()))
            {
                string tempGuessList = string.Empty;
                for (int i = 0; i < guess.Length; i++)
                {
                    tempGuessList += guess[i];
                }

                for (int i = 0; i < actualWord.Length; i++)
                {
                    if (tempGuessList[i] == actualWord[i])
                    {
                        hiddenWord[i] = tempLetter.ToString();
                        tempHiddenWord = string.Join(" ", hiddenWord);
                    }

                }
                return true;

            }
            return false;
        }
    }   
}
