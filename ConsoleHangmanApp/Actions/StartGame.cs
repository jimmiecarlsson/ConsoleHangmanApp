using System;
using System.Diagnostics.Metrics;

namespace ConsoleHangmanApp.Actions
{
    public class StartGame
    {
        string chooseWord = Words.GetRandomWord();
        char letter = ' ';
        List<char> guessedLetters = new List<char>();
        int maxAttempts = 10;
        string[] incorrectGuesses = new string[10];
        int incorrectGuessCount = 0;
        string[] correctGuesses = new string[10];
        int correctGuessCount = 0;


        public void GetLetter()
        {
            if (chooseWord == null || chooseWord.Length == 0)
            {
                Console.WriteLine("The word to guess is empty or null. Please restart the game.");
                return;
            }

            //Console.WriteLine($"The word to guess is: {chooseWord}");
            Console.Clear();
            Console.WriteLine("Guess a letter or \npress SPACE to guess the whole word:");

            letter = Console.ReadKey().KeyChar;
            // Check if the input is a space character
            if (letter == ' ')
            {
                Console.WriteLine("\nYou chose to guess the whole word.");
                Console.Write("Please enter your guess: ");
                string wordGuess = Console.ReadLine()?.Trim().ToLower();
                if (wordGuess == chooseWord)
                {
                    CheckWinCondition();
                }
                else
                {
                    Console.WriteLine($"Sorry, '{wordGuess.ToUpper()}' is not the correct word.");
                
                }
                return;
            }
            if (!char.IsLetter(letter) && letter != ' ')
            {
                Console.WriteLine("\nPlease enter a letter (A-Ö).");
                return;
            }

            // add the guessed letter to the list
            guessedLetters.Add(letter);

            string letterString = letter.ToString().ToLower();

            Console.WriteLine();
            Console.WriteLine($"You guessed the letter: {letter.ToString().ToUpper()}");

            bool isLetterInWord = chooseWord.Contains(letterString);

            if (isLetterInWord)
            {
                Console.WriteLine($"Correct! The letter '{letter.ToString().ToUpper()}' is in the word.");
                correctGuesses[correctGuessCount] = letter.ToString().ToUpper();
                correctGuessCount++;
            }
            else
            {
                Console.WriteLine($"Incorrect! The letter '{letter.ToString().ToUpper()}' is not in the word.");
                incorrectGuesses[incorrectGuessCount] = letter.ToString().ToUpper();
                incorrectGuessCount++;
            }


        }

        public void CheckWinCondition()
        {
            Console.WriteLine($"Congratulations! You guessed the word '{chooseWord.ToUpper()}' correctly!");
        }
        public void DisplayCurrentState()
        {
            foreach (char c in chooseWord)
            {
                if (guessedLetters.Contains(char.ToLower(c)))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(c.ToString().ToUpper() + " ");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write("_ ");
                    Console.ResetColor();
                }
            }
            Console.WriteLine("Incorrect choosen letter.");
            for (int i = 0; i < incorrectGuessCount+1; i++)
            {
                if (incorrectGuesses[i] != "")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(incorrectGuesses[i] + " ");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("No guesses are incorrect still.");
                }
            }
            Console.WriteLine(" ");
        }
    }
}


