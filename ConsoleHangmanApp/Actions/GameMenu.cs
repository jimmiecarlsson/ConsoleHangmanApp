using System;

namespace ConsoleHangmanApp.Actions
{
    public class GameMenu
    {
        public void ShowGameMenu() {
            Console.Clear();
            string[] menuText = { 
                "Hangman Game!\n",
                "S. Start Game",
                "Q. Exit\n",
                "Choose an option: "
            };
        
            for (int i=0; i<4; i++) {

                // Set color based on index
                if (i == 0) {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                } else if (i == 1) {
                    Console.ForegroundColor = ConsoleColor.Green;
                } else if (i == 2) {
                    Console.ForegroundColor = ConsoleColor.Red;
                } else {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                }

                Console.WriteLine(menuText[i]);

                // Reset color after each line
                Console.ResetColor();
            }
        }
    }
}
