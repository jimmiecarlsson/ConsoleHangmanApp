using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHangmanApp.Actions
{
    public class StartGame
    {
        public StartGame() {

            //string myWord = Words.GetRandomWord();

            //Console.WriteLine($"The word to guess is: {myWord}");

            Console.Clear();
            Console.WriteLine("\nHangman Game Started ...");

            Console.ReadLine();

        }
    }
    // Here you can add more methods to handle the game logic, such as guessing letters, checking win/lose conditions, etc.
    // For example:
    // public void GuessLetter(char letter) { ... }
    // public void CheckWinCondition() { ... }
    // public void DisplayCurrentState() { ... }
}

