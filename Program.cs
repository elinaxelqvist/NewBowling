public class Program
{
    public static void Main(string[] args)
    {
        BowlingLane lane = new BowlingLane();
        lane.Print();

        IThrow power = new WeakPower();  // Exempel: Spelaren väljer starkt kast
        IThrow direction = new RightDirection();  // Exempel: Spelaren väljer rak riktning

        Player player = new Player("Player 1", power, direction);
        player.PerformThrow(lane);  // Spelaren kastar på banan

        Console.ReadLine();
    }
}