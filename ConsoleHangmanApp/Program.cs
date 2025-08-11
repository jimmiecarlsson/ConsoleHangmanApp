// See https://aka.ms/new-console-template for more information


bool appIsRunning = true;

while (appIsRunning)
{
Console.WriteLine("\nHangman Game");
    Console.WriteLine("S. Start Game");
    Console.WriteLine("Q. Exit");   
    
    Console.Write("Choose an option: ");
    string? input = Console.ReadLine();

    switch{

        case "s":
            Console.WriteLine("Starting the game...");
            // Here you would call the method to start the game
            // For example: StartGame();

            break;
        case "q":
            Console.WriteLine("Exiting the game. Goodbye!");
            appIsRunning = false;
            break;
        default:
            Console.WriteLine("Invalid option, please try again.");
            break;
    };










}


