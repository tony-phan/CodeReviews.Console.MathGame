using MathGame;

bool flag = true;
Game game = new Game(new List<GameLog>());

while (flag)
{
    game.ShowGameMenu();
    Console.Write("Please choose an operation: ");
    int option = Convert.ToInt32(Console.ReadLine());
    switch (option) 
    {
        case 1:
            game.PerformOperation("+");
            break;
        case 2:
            game.PerformOperation("-");
            break;
        case 3:
            game.PerformOperation("*");
            break;
        case 4:
            game.PerformOperation("/");
            break;
        case 5:
            game.DisplayGameHistory();
            break;
        case 6:
            game.ShowGameScore();
            flag = !flag;
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
}

Console.ReadKey();