namespace Homework6.Models;

public class Quest
{
    public string Title { get; set; } = String.Empty;
    public int DifficultyLevel { get; set; } = 0;
    public int Bonus { get; set; } = 0;
    public TimeSpan Duration { get; set; } = TimeSpan.Zero;

    public override string ToString()
    {
        return $"{Title}, {DifficultyLevel}, {Bonus}";
    }
}