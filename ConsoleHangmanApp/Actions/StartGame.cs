using System;
using System.Diagnostics.Metrics;

namespace ConsoleHangmanApp.Actions
{
    public class StartGame
    {
        string chooseWord = Words.GetRandomWord();
        char letter = ' ';

        public void GetLetter()
        {
            if (chooseWord == null || chooseWord.Length == 0)
            {
                Console.WriteLine("The word to guess is empty or null. Please restart the game.");
                return;
            }

            Console.WriteLine($"The word to guess is: {chooseWord}");

            Console.WriteLine("Guess a letter:");

            letter = Console.ReadKey().KeyChar;
            if (!char.IsLetter(letter))
            {
                Console.WriteLine("\nPlease enter a letter (A-Ö).");
                return;
            }



            string letterString = letter.ToString().ToLower();

            Console.WriteLine();
            Console.WriteLine($"You guessed the letter: {letter.ToString().ToUpper()}");
            

            bool isLetterInWord = chooseWord.Contains(letterString);

            if (isLetterInWord)
                {
                
                Console.WriteLine($"Correct! The letter '{letter.ToString().ToUpper()}' is in the word.");
                }
                else
                {
                    Console.WriteLine($"Incorrect! The letter '{letter.ToString().ToUpper()}' is not in the word.");
                }


        }

        public void CheckWinCondition()
        {



        }
        public void DisplayCurrentState()
        { 
            foreach (char c in chooseWord)
            {
                if (c == letter)
                {
                    Console.Write(c + " ");
                }
                else
                {
                    Console.Write("_ ");
                }
            }
        }
    }
}


