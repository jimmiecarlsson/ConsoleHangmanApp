using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
