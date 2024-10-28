public class Game
{
    private BowlingLane lane;
    private Player player;

    public Game()
    {
        lane = new BowlingLane();
        player = new Player("Player 1", null, null);
    }

    public void PlayGame()
    {
        lane.Print();

        while (true)
        {
            PlayTurn();

            if (lane.AllPinsDown())
            {
                Console.WriteLine("All pins are down! Game over!");
                break;
            }

            Console.WriteLine("\nDo you want to throw again? (y/n)");
            if (Console.ReadLine().ToLower() != "y")
                break;
        }

        Console.WriteLine("Game Over!");
    }

    private void PlayTurn()
    {
        Console.WriteLine("\nChoose your direction:");
        Console.WriteLine("1. Left");
        Console.WriteLine("2. Straight");
        Console.WriteLine("3. Right");
        Console.Write("Input (1-3): ");
        int directionChoice = int.Parse(Console.ReadLine());

        IStrategy direction;
        switch (directionChoice)
        {
            case 1:
                direction = new ForwardSpinStrategy();
                break;
            case 2:
                direction = new StraightStrategy();
                break;
            case 3:
                direction = new BackSpinStrategy();
                break;
            default:
                Console.WriteLine("Invalid choice. Defaulting to Straight.");
                direction = new StraightStrategy();
                break;
        }

        Console.WriteLine("\nChoose your power:");
        Console.WriteLine("1. Weak");
        Console.WriteLine("2. Strong");
        Console.Write("Input (1-2): ");
        int powerChoice = int.Parse(Console.ReadLine());

        IThrow power = powerChoice == 1 ? 
            new WeakPower(direction) : 
            new StrongPower(direction);

        player = new Player("Player 1", power, power);
        player.PerformThrow(lane);
    }
}
