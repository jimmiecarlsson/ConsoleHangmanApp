
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
            break;
        case "q":
            Console.WriteLine("Exiting the game...");
            CloseApp closeApp = new CloseApp();
            closeApp.Close();
            break;
        default:
            Console.WriteLine("Invalid option, please try again.");
            break;
    };










}


