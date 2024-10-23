public interface IThrow
{
    public string Name { get; }
    public string Description { get; }
    public int Number { get; }
}

class WeakPower : IThrow
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Number { get; private set; }

    public WeakPower()
    {
        Name = "Weak";
        Description = "¨For Pins in the front row";
        Number = 10;
    }
}

class StrongPower : IThrow
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Number { get; private set; }

    public StrongPower()
    {
        Name = "Strong";
        Description = "¨For Pins in the back row";
        Number = 100;
    }
}

class LeftDirection : IThrow
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Number { get; private set; }

    public LeftDirection()
    {
        Name = "Left";
        Description = "Hits the left side of the lane";
        Number = 0;
    }
}

class StraightDirection : IThrow
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Number { get; private set; }

    public StraightDirection()
    {
        Name = "Straight";
        Description = "Hits the middle of the lane";
        Number = 50;
    }
}

class RightDirection : IThrow
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Number { get; private set; }

    public RightDirection()
    {
        Name = "Right";
        Description = "Hits the right side of the lane";
        Number = 100;
    }
}

public class Player
{
    public string Name { get; private set; }
    public IThrow PowerType { get; private set; }
    public IThrow DirectionType { get; private set; }

    public Player(string playerName, IThrow powerType, IThrow directionType)
    {
        Name = playerName;
        PowerType = powerType;
        DirectionType = directionType;
    }

    public void PerformThrow(BowlingLane lane)
    {
        Console.WriteLine($"{Name} is preparing a throw with {PowerType.Name} power and aiming {DirectionType.Name}.");

        // Anropar MakeThrow från BowlingLane med spelarens power och direction
        lane.MakeThrow(PowerType.Number, DirectionType.Number);
    }
}