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
        static int counterLives = 7;
        static string usersGuess = string.Empty;
        static bool playing = true;
        public static List<string> hiddenWord = new List<string> {};
        static string actualWord = string.Empty;
        static string tempHiddenWord = string.Empty;
        static string previousGuesses = string.Empty;
        static void Main(string[] args)
        {
            StartScreen();
            WordHidden();
            while (playing == true)
            {
                Console.Clear();
                Console.WriteLine("You have {0} lives left", counterLives);
                Console.WriteLine(tempHiddenWord);
                Console.Write("Guesses: ");
                IncrementGuessString(usersGuess);
                string userUnvalidated = Console.ReadLine();
                if (ValidateUserInput(userUnvalidated))
                {
                        if (counterLives != 0 )
                        {
                            if (tempHiddenWord == MakeWordSpace(actualWord))
                            {
                                Console.WriteLine("Congradulations You win");
                                playing = false;
                            }
                                if ()
                                {
                                    ChangeHiddenWord(usersGuess);                                
                                }
                                else
                                {
                                    counterLives--;
                                }
                        }
                        else
                        {
                            Console.WriteLine("You have lost the game");
                            playing = false;
                            Console.ReadKey();
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
        static string MakeWordSpace(string input)
        {
            List<char> tempActualList = new List<char> { };
                for (int i = 0; i < input.Length; i++)
			{
                tempActualList.Add(input[i]);
			}
                tempActualList.ToArray();
            string tempActualstring = string.Join(" ", tempActualList);
            return  tempActualstring;

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
            previousGuesses += (letterGuessed + " ");
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

                if (tempGuessList.ToUpper() == actualWord)
                {
                    tempHiddenWord = string.Join(" ", tempGuessList).ToUpper();
                    return false;
                }

                for (int i = 0; i < actualWord.Length; i++)
                {

                    if (tempGuessList.ToUpper()[0] == actualWord[i] && guess.Length == 1)
                    {
                        string[] temptempHiddenword = tempHiddenWord.Split(' ');
                        temptempHiddenword[i] = tempGuessList.ToString().ToUpper();
                        tempHiddenWord = string.Join(" ", temptempHiddenword);
                    }

                }
                return true;

            }
            return false;
        }
    }   
}
