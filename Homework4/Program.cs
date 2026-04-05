using Homework4.Task2;

namespace Homework4;

class Program
{
    private static readonly int _orderCount = 10;
    private static CountdownEvent cd = new CountdownEvent(_orderCount);
    
    static void OrderProcessor(object obj)
    {
        int orderId = (int)obj;

        Console.WriteLine($"Order Id: {orderId} was managed by {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(1000);
        
        cd.Signal();
    }
    
    static void Main(string[] args)
    {

        for (int i = 0; i < _orderCount; i++)
        {
            ThreadPool.QueueUserWorkItem(OrderProcessor, i);
        }

        cd.Wait();

        Console.WriteLine("All orders were completed");
    }
}