using System;

namespace ConsoleHangmanApp.Actions
{
    public class StartGame
    {
        string chooseWord = Words.GetRandomWord().ToLower();
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
            
                string wordGuess = Console.ReadLine().ToLower();
                
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

            // Check if the input is a valid letter (A-Ö)
            if (!char.IsLetter(letter) && letter != ' ')
            {
                Console.WriteLine("\nPlease enter a letter (A-Ö).");
                return;
            }


            // add the guessed letter to the list
            guessedLetters.Add(char.ToLower(letter));

            // Print the guessed letter
            Console.WriteLine();
            Console.WriteLine($"You guessed the letter: {letter.ToString().ToUpper()}");

            // Check if the letter is in the word
            string letterString = letter.ToString().ToLower();
            bool isLetterInWord = chooseWord.Contains(letterString);

            if (isLetterInWord)
            {
                for (int i = 0; i < correctGuessCount; i++)
                {
                    if (correctGuesses[i] != null && correctGuesses[i] == char.ToString(letter).ToLower())
                    {
                        Console.WriteLine($"You have already guessed the letter '{letter.ToString().ToUpper()}'.");
                        return;
                    }

                }

                Console.WriteLine($"Correct! The letter '{letter.ToString().ToUpper()}' is in the word.\n");
                correctGuesses[correctGuessCount] = letter.ToString().ToLower();
                correctGuessCount++;
            }
            else
            {
                for (int i = 0; i < incorrectGuessCount; i++)
                {
                    if (incorrectGuesses[i] != null && incorrectGuesses[i] == char.ToString(letter).ToLower())
                    {
                        Console.WriteLine($"You have already guessed the letter '{letter.ToString().ToUpper()}'.");
                        return;
                    }

                }

                Console.WriteLine($"Incorrect! The letter '{letter.ToString().ToUpper()}' is not in the word.\n");
                incorrectGuesses[incorrectGuessCount] = letter.ToString().ToLower();
                incorrectGuessCount++;
            }


        }

        public void CheckWinCondition()
        {

            Console.WriteLine($"Congratulations! You guessed the word '{chooseWord.ToUpper()}' correctly!");
        }
        public void DisplayCurrentState()
        {
            Console.WriteLine("\nCorrect choosen letters.");

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
            Console.WriteLine("\nIncorrect choosen letter so far.");
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


