
using ConsoleHangmanApp.Actions;

bool appIsRunning = true;

while (appIsRunning)
{
    
    string input = Console.ReadKey(true).KeyChar.ToString();

    switch (input.ToLower()){

        case "s":
            Console.WriteLine("Starting the game...");
            // Here you would call the method to start the game
            // For example: StartGame();

            string myWord = Words.GetRandomWord();

            Console.WriteLine($"The word to guess is: {myWord}");

            Console.ReadLine(); // Wait for user input before continuing


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


