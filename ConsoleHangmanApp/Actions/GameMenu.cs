using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHangmanApp.Actions
{
    public class GameMenu
    {

        public GameMenu() {
            Console.Clear();
            Console.WriteLine("\nHangman Game");
            Console.WriteLine("S. Start Game");
            Console.WriteLine("Q. Exit");
            Console.Write("Choose an option: ");
        }
    }
}
