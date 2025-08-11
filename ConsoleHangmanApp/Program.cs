using ConsoleHangmanApp.Actions;

bool appIsRunning = true;

while (appIsRunning)
{
    GameMenu gameMenu = new GameMenu();
    gameMenu.ShowGameMenu();

    string input = Console.ReadKey(true).KeyChar.ToString();

    switch (input.ToLower()){

        case "s":
            Console.WriteLine("Starting the game...");
            StartGame startGame = new StartGame();
            Console.Clear();

            for (int turns = 0; turns < 10; turns++)
            {
                startGame.GetLetter();
                startGame.DisplayCurrentState();
                Console.WriteLine($"Turns left: {10 - turns}");

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
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }











}


