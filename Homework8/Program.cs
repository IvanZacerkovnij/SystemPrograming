namespace Homework8;

class Program
{
    static Semaphore semaphore = new Semaphore(1,6);

    static void Work(object id)
    {
        Console.WriteLine($"Thread {id} чекає...");
        try
        {
            var entered = semaphore.WaitOne(10000); //Якщо семафор не захопив потік ,то виходимо
            if (!entered)                                                //інакше блок Finally викличе Release на
            {                                                            //не існуючий потік і вилізе Exception
                return;                                                  //Сам WaitOne указує на те чи зайнятий ресурс
            }                                                            //на даний ресурс і блокує його на час очікування
            Console.WriteLine($"Thread {id} зайшов");                    //https://learn.microsoft.com/ru-ru/dotnet/api/system.threading.waithandle?view=net-8.0
            Thread.Sleep(2000);                          //Коментарі другий абзац
        }
        finally
        {
            Console.WriteLine($"Thread {id} виходить");
            semaphore.Release();
        }
    }
    static void Main(string[] args)
    {
        List<Thread> threads = new List<Thread>();

        for (int i = 0; i < Environment.ProcessorCount; i++)
        {
            threads.Add(new Thread(Work));
        }

        foreach (var thread in threads)
        {
            thread.Start(thread.ManagedThreadId);
        }
    }
}