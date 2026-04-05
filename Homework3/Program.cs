namespace Homework3;

class Program
{
    private static readonly int _printCount = 20;
    
    static void PrintLow()
    {
        for (int i = 0; i < _printCount; i++)
        {
            Console.WriteLine("Low");
            Thread.Sleep(100);
        }
    }

    static void PrintNormal()
    {
        for (int i = 0; i < _printCount; i++)
        {
            Console.WriteLine("Normal");
            Thread.Sleep(100);
        }
    }

    static void PrintHigh()
    {
        for (int i = 0; i < _printCount; i++)
        {
            Console.WriteLine("High");
            Thread.Sleep(100);
        }
    }
    
    
    static void Main(string[] args)
    {
        Thread threadLow = new Thread(PrintLow);
        Thread threadNormal = new Thread(PrintNormal);
        Thread threadHigh = new Thread(PrintHigh);
        
        threadLow.Priority = ThreadPriority.Lowest;
        threadNormal.Priority = ThreadPriority.Normal;
        threadHigh.Priority = ThreadPriority.Highest;
        
        threadLow.Start();
        threadNormal.Start();
        threadHigh.Start();
    }
}