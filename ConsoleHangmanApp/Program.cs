using ConsoleHangmanApp.Actions;

bool appIsRunning = true;

while (appIsRunning)
{
    GameMenu gameMenu = new GameMenu();
    gameMenu.ShowGameMenu();

    string input = Console.ReadKey(true).KeyChar.ToString();

    switch (input.ToLower()){

        case "s":
            StartGame startGame = new StartGame();
            Console.Clear();

            while (startGame.AttemptsUsed < 10 && !startGame.IsWon)
            {
                startGame.GetLetter();
                //startGame.DisplayCurrentState();
                Console.WriteLine($"Turns left: {10 - startGame.AttemptsUsed}");

                PausForKeyPress();
            }

            if (startGame.IsWon)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Congratulations, you won! The word was: {startGame.WordToGuess.ToUpper()}");
                Console.ResetColor();

                PausForKeyPress();

            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"GAME OVER! The word was: {startGame.WordToGuess.ToUpper()}");
                Console.ResetColor();
                
                PausForKeyPress();
            }

            break;
        case "q":
            Console.Clear();
            Console.WriteLine("Exiting the game...");
            PausForKeyPress();
            CloseApp closeApp = new CloseApp();
            closeApp.Close();
            break;
        default:
            Console.WriteLine("Invalid option, please try again.");
            PausForKeyPress();
            break;
    };

    // Local method to pause for key press

    static void PausForKeyPress()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Console.ResetColor();
    }











}


