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

        bool wordGuessed = false;

        // Properties to access the game state to the main program (testing to use)
        public int AttemptsUsed
        {
            get
            {
                return correctGuessCount + incorrectGuessCount;
            }
        }
        public bool IsWon
        {
            get
            {
                if (wordGuessed) { 
                    return true;
                }

                foreach (char c in chooseWord)
                {
                    if (!guessedLetters.Contains(char.ToLower(c)))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public string WordToGuess
        {
            get
            {
                return chooseWord;
            }
        }


        public void GetLetter()
        {
            if (chooseWord == null || chooseWord.Length == 0)
            {
                Console.WriteLine("The word to guess is empty or null. Please restart the game.");
                return;
            }

            DisplayPrompt();

            letter = Console.ReadKey().KeyChar;

            // Check if the input is a space character
            if (letter == ' ')
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nYou chose to guess the whole word.");
                Console.Write("Please enter your guess: ");
                Console.ResetColor();

                string wordGuess = Console.ReadLine().ToLower();
                
                if (wordGuess == chooseWord)
                {
                    wordGuessed = true;
                    DisplayWinCondition();
                }
                else
                {
                    if (wordGuess == null)
                    {
                       wordGuess = "";
                    }
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Sorry, '{wordGuess.ToUpper()}' is not the correct word.");
                    Console.ResetColor();

                    if (incorrectGuessCount < maxAttempts)
                    {
                        incorrectGuesses[incorrectGuessCount] = wordGuess.ToLower();
                        incorrectGuessCount++;
                    }
                   
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
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"You guessed the letter: {letter.ToString().ToUpper()}");

            // Check if the letter is in the word
            string letterString = letter.ToString().ToLower();
            bool isLetterInWord = chooseWord.Contains(letterString);

            bool alreadyGuessed = false;
            
            if (isLetterInWord)
            {
                for (int i = 0; i < correctGuessCount; i++)
                {
                    if (correctGuesses[i] != null && correctGuesses[i] == char.ToString(letter).ToLower())
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"You have already guessed the letter '{letter.ToString().ToUpper()}'.");
                        Console.ResetColor();
                        alreadyGuessed = true;

                        return;

                    }

                }

                // If the letter is not already guessed, add it to the correct guesses
                if (!alreadyGuessed) { 
                    correctGuesses[correctGuessCount] = letter.ToString().ToLower();
                    correctGuessCount++;
                }
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nCorrect! The letter '{letter.ToString().ToUpper()}' is in the word.\n");
                Console.ResetColor();
            }
            else
            {
                for (int i = 0; i < incorrectGuessCount; i++)
                {
                    if (incorrectGuesses[i] != null && incorrectGuesses[i] == char.ToString(letter).ToLower())
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"You have already guessed the letter '{letter.ToString().ToUpper()}'.");
                        Console.ResetColor();
                        alreadyGuessed = true;
                        return;
                    }

                }

                // If the letter is not already guessed, add it to the incorrect guesses
                if (!alreadyGuessed)
                {
                    incorrectGuesses[incorrectGuessCount] = letter.ToString().ToLower();
                    incorrectGuessCount++;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nIncorrect! The letter '{letter.ToString().ToUpper()}' is not in the word.\n");
                Console.ResetColor();
            }


        }

        private void DisplayPrompt()
        {
            Console.Clear();
            DisplayCurrentState();

            // Prompten för inmatning
            Console.WriteLine("Guess a letter or");
            Console.WriteLine("press SPACE to guess the whole word:");
        }

        public void DisplayWinCondition()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nCongratulations! You guessed the word {chooseWord.ToUpper()} correctly!");
            Console.ResetColor();
        }

        public void DisplayCurrentState()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Hangman Game!");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Attempts used: {AttemptsUsed} of {maxAttempts}");
            Console.ResetColor();
            Console.WriteLine("\nThe word");

            foreach (char c in chooseWord)
            {
                // Primary display

                if (guessedLetters.Contains(char.ToLower(c)))
                {
                    // Display the correct letter in green
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(c.ToString().ToUpper() + " ");
                    Console.ResetColor();
                }
                else
                {
                    // Display an underscore for unguessed letters
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write("_ ");
                    Console.ResetColor();
                }
            }

            Console.WriteLine();
            PrintIncorrectLetters();
            Console.WriteLine();
            PrintIncorrectWords();

        }

        private void PrintIncorrectLetters()
        {
            bool any = false;
            for (int i = 0; i < incorrectGuessCount; i++)
            {
                if (!string.IsNullOrEmpty(incorrectGuesses[i]) && incorrectGuesses[i].Length == 1)
                {
                    if (!any)
                    {
                        Console.Write("\nIncorrect letters: ");
                        any = true;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(incorrectGuesses[i].ToUpper());
                    Console.ResetColor();
                    Console.Write(" ");
                }
            }
            if (!any)
            {
                Console.WriteLine("\nIncorrect letters: (none)");
            }
        }

        private void PrintIncorrectWords()
        {
            bool any = false;
            for (int i = 0; i < incorrectGuessCount; i++)
            {
                if (!string.IsNullOrEmpty(incorrectGuesses[i]) && incorrectGuesses[i].Length > 1)
                {
                    if (!any)
                    {
                        Console.Write("\nIncorrect words: ");
                        any = true;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(incorrectGuesses[i].ToUpper());
                    Console.ResetColor();
                    Console.Write(" ");
                }
            }
            if (!any)
            {
                Console.WriteLine("\nIncorrect words: (none)");
            }
        }




    }
}


