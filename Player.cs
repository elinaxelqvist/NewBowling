using System;
using System.Drawing;
using System.Numerics;

public interface IThrow  //IStrategy instansieras i IThrow, IThrow behöver IStrategy  
{
     IStrategy Strategy { get; }
    public string Name { get; }
    public string Description { get; }
    public int Number { get; }
}

public interface IStrategy
{
    public string Name { get; }
    public int Number { get; }

    (bool hit, string result) Spin();
}

class WeakPower : IThrow //Ev att göra power till samma klass: IPower
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Number { get; private set; }

    public IStrategy Strategy { get; private set; }

    public WeakPower(IStrategy strategy)
    {
        Name = "Weak";
        Description = "¨For Pins in the front row";
        Number = 10;
        Strategy = strategy;
    }
}

class StrongPower : IThrow
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Number { get; private set; }

    public IStrategy Strategy { get; private set; }

    public StrongPower(IStrategy strategy)
    {
        Name = "Strong";
        Description = "¨For Pins in the back row";
        Number = 100;
        Strategy = strategy;
    }
}

class ForwardSpinStrategy : IStrategy
{

    //public LeftDirection(IThrow throww) : base(throww) { }
    public string Name { get; private set; }
   // public string Description { get; private set; }
    public int Number { get; private set; }

    public ForwardSpinStrategy()
    {
        Name = "ForwardSpin";
        Number = 0;
    }

    public (bool hit, string result) Spin()
    {
        Random random = new Random();
        int spinChance = random.Next(1, 101);
        bool willHit = spinChance <= 50;

        return (willHit, willHit ? "forward spin" : "Ops! You slipped!");
    }
}

class StraightStrategy : IStrategy
{
    public string Name { get; private set; }
   // public string Description { get; private set; }
    public int Number { get; private set; }


    public StraightStrategy()
    {
        Name = "Straight";
        //Description = "Hits the middle of the lane";
        Number = 50;
    }

    public (bool hit, string result) Spin()
    {
        Random random = new Random();
        int spinChance = random.Next(1, 101);
        bool willHit = spinChance <= 70;

        return (willHit, willHit ? "straight spin" : "Oh no... The ball went out of the lane...");
    }
}


class BackSpinStrategy : IStrategy
{
    public string Name { get; private set; }
   // public string Description { get; private set; }
    public int Number { get; private set; }


    public BackSpinStrategy()
    {
        Name = "Right";
        //Description = "Hits the right side of the lane";
        Number = 100;
    }

    public (bool hit, string result) Spin()
    {
        Random random = new Random();
        int spinChance = random.Next(1, 101);
        bool willHit = spinChance <= 60;

        return (willHit, willHit ? "back spin" : "Wops, too much power! The ball got in another persons lane...");
    }
}


public class Player
{
    public string Name { get; private set; }
    public IThrow PowerType { get; private set; }
    public IThrow StrategyType { get; private set; }
    public Score PlayerScore { get; private set; }

    public Player(string playerName, IThrow powerType, IThrow strategyType)
    {
        Name = playerName;
        PowerType = powerType;
        StrategyType = strategyType;
        PlayerScore = new Score(); // Initiera Score här
    }

    public void UpdateThrowSettings(IThrow powerType, IThrow strategyType)
    {
        PowerType = powerType;
        StrategyType = strategyType;
    }

    public void PerformThrow(BowlingLane lane)
    {
        Console.WriteLine($"{Name} is preparing a throw with {PowerType.Name} power and aiming {StrategyType.Name}.");
        
        var (hit, result) = PowerType.Strategy.Spin();
        
        if (hit)
        {
            Console.WriteLine($"The ball had good {result}!");
            int pinsDown = lane.MakeThrow(PowerType.Number, PowerType.Strategy.Number);
            PlayerScore.AddPoints(pinsDown);
            Console.WriteLine($"Current score: {PlayerScore.GetTotalScore()}");
        }
        else
        {
            Console.WriteLine($"The throw missed due to {result}!");
            lane.Print();
        }
    }
}

// public interface IDecisionEngine
// {
//     IThrow ChoosePower();
//     IThrow ChooseDirection();
// }
// public class RandomDecisionEngine : IDecisionEngine
// {
//     private Random random = new Random();
//     public IThrow ChoosePower()
//     {
//         // Slumpar mellan 1 (WeakPower) och 2 (StrongPower)
//         return random.Next(1, 3) == 1 ? new WeakPower() : new StrongPower();
//     }
//     public IThrow ChooseDirection()
//     {
//         // Slumpar mellan 1 (Left), 2 (Straight) och 3 (Right)
//         switch (random.Next(1, 4))
//         {
//             case 1:
//                 return new LeftDirection();
//             case 2:
//                 return new StraightDirection();
//             case 3:
//                 return new RightDirection();
//             default:
//                 return new StraightDirection(); // Fallback
//         }
//     }
// }
// public class ComputerPlayer
// {
//     public string Name { get; private set; }
//     private IThrow PowerType { get; set; }
//     private IThrow DirectionType { get; set; }
//     private IDecisionEngine decisionEngine;

//     public ComputerPlayer(string playerName)
//     {
//         Name = playerName;
//         decisionEngine = new RandomDecisionEngine();
//         ChooseRandomThrow(); // Välj ett slumpmässigt kast direkt vid skapandet
//     }
//     private void ChooseRandomThrow()
//     {
//         PowerType = decisionEngine.ChoosePower();
//         DirectionType = decisionEngine.ChooseDirection();
//     }

//     public void PerformThrow(BowlingLane lane)
//     {
//         Console.WriteLine($"{Name} is preparing a throw with {PowerType.Name} power and aiming {DirectionType.Name}.");
//         lane.MakeThrow(PowerType.Number, DirectionType.Number);
//     }
// }
