using System;

namespace ConsoleHangmanApp.Actions
{
    internal class CloseApp
    {
        public CloseApp() { }

        public void Close()
        {
            Console.Clear();
            Console.WriteLine("\nThank you for playing Hangman!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
