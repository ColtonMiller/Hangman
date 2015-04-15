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
        static void Main(string[] args)
        {
            StartScreen();
        }
        static void StartScreen()
        {
            Console.WriteLine("Welcome to Hangman what is your name user?");
            usersName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Welcome {0} You have 8 chances to guess the word using either a letter or by trying to guess the word itself",usersName);
            Console.ReadKey();
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
    }   
}
