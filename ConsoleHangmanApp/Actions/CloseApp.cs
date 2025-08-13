using System;

namespace ConsoleHangmanApp.Actions
{
    internal class CloseApp
    {
        public CloseApp() { }

        public void Close()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nThank you for playing Hangman!");
            Console.ResetColor();
            Console.WriteLine();
            Environment.Exit(0);
        }
    }
}
