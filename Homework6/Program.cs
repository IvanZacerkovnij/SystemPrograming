using System.Diagnostics;
using System.Timers;
using Homework6.Models;

namespace Homework6;

class Program
{
    private static Stopwatch _stopwatch = Stopwatch.StartNew();

    private static string Timer()
    {
        TimeSpan ts = _stopwatch.Elapsed;
        return $"{ts:mm\\:ss\\.fff}";

    }
    private static bool CalculateResult(Hero hero, Quest quest)
    {
        int heroStat =  hero.Power + Random.Shared.Next(1, 20);
        int questStat =  quest.DifficultyLevel * 10 + Random.Shared.Next(1, 20);
        return heroStat >= questStat;
    }
    public static async Task RunQuestAsync(Hero hero, Quest quest,  CancellationTokenSource cts)
    {
        Console.WriteLine($"[{Timer()}] Hero: {hero.Name} started quest {quest.Title}.");
        try
        {
            await Task.Delay(quest.Duration, cts.Token);
            if (CalculateResult(hero, quest))
            {
                Console.WriteLine($"[{Timer()}] Hero: {hero.Name} completed quest {quest.Title}. Bonus: {quest.Bonus}.");
            }
            else
            {
                Console.WriteLine($"[{Timer()}] Hero: {hero.Name} failed quest {quest.Title}.");
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine($"[{Timer()}] Hero: {hero.Name} run away from quest {quest.Title}.");
        }
    }
    
    static async Task Main(string[] args)
    {
        var alice = new Hero() { Name = "Alice" };
        var bob = new Hero() { Name = "Bob", Power = 30 };
        
        var dragonCave = new Quest(){
            Bonus = 350,
            Title = "Dragon cave",
            DifficultyLevel = 4,
            Duration = TimeSpan.FromSeconds(15),
        };
        var wizardTower = new Quest() {
            Bonus = 150,
            Title = "Wizard tower",
            DifficultyLevel = 2,
            Duration = TimeSpan.FromSeconds(10),
        };
        var bobCts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        var aliceCts = new CancellationTokenSource();
        
        Task bobTask = RunQuestAsync(bob, dragonCave, bobCts);
        Task aliceTask = RunQuestAsync(alice, wizardTower, aliceCts);

        Task.WaitAll(bobTask, aliceTask);
    }
}