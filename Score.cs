using System.Collections.Generic;

public class Score : IEnumerable<int>
{
    private List<int> throwScores;  // Sparar poäng för varje kast
    private int currentScore;

    public Score()
    {
        throwScores = new List<int>();
        currentScore = 0;
    }

    public void AddPoints(int points)
    {
        throwScores.Add(points);  // Lägg till poäng för detta kast
        currentScore += points;
    }

    public int GetTotalScore()
    {
        return currentScore;
    }

    // Implementera IEnumerable för att kunna iterera över kasten
    public IEnumerator<int> GetEnumerator()
    {
        return throwScores.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Metoder för statistik
    public double GetAverageScore()
    {
        return throwScores.Count > 0 ? throwScores.Average() : 0;
    }

    public int GetHighestScore()
    {
        return throwScores.Count > 0 ? throwScores.Max() : 0;
    }

    // Visa poänghistorik
    public void PrintScoreHistory()
    {
        Console.WriteLine("\nScore History:");
        for (int i = 0; i < throwScores.Count; i++)
        {
            Console.WriteLine($"Throw {i + 1}: {throwScores[i]} points");
        }
        Console.WriteLine($"Total Score: {currentScore}");
    }
}
