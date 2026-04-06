using System.Collections.Concurrent;
using Homework7.Models;

namespace Homework7;

class Program
{
    static ConcurrentQueue<Client> _clients = new();
    
    static ConcurrentStack<String> _actions = new();

    static void AddAction(List<string> actions)
    {
        foreach (var action in actions)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Action \"{action}\" has been added by {Thread.CurrentThread.ManagedThreadId}.");
            _actions.Push(action);
        }
    }

    static void CancelLastAction()
    {
        while (!_actions.IsEmpty)
        {
            if (_actions.TryPop(out var action))
            {
                Thread.Sleep(300);
                Console.WriteLine($"Action \"{action}\" has been cancelled by the {Thread.CurrentThread.ManagedThreadId}.");
            }
        }

        Console.WriteLine($"All actions have been cancelled by the {Thread.CurrentThread.ManagedThreadId}.");
    }

    static void AddClient(List<Client> clients)
    {
        foreach (var client in clients)
        {
            Thread.Sleep(300);
            _clients.Enqueue(client);
            Console.WriteLine($"Client {client.Name} has been added by {Thread.CurrentThread.ManagedThreadId}.");
        }
    }

    static void ProcessClients()
    {
        while (!_clients.IsEmpty)
        {
            if (_clients.TryDequeue(out var client))
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} processing client {client.Name}");
                Thread.Sleep(1000);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} processed client {client.Name}");
            }
            else
            {
                Thread.Sleep(500);
            }
        }
        Console.WriteLine($"All clients have been processed by {Thread.CurrentThread.ManagedThreadId}.");
    }
    
    static void Main(string[] args)
    {
        //Task1
        // List<Client> clients1 = new();
        // List<Client> clients2 = new();
        //
        // clients1.Add(new Client("Марія", "Відкрити рахунок"));
        // clients1.Add(new Client("Олег", "Перевірити рахунок"));
        // clients1.Add(new Client("Дмитрій", "Закрити рахунок"));
        //
        // clients2.Add(new Client("Іван", "Поповнити рахунок"));
        // clients2.Add(new Client("Олексій", "Зняти кошти з рахунку"));
        // clients2.Add(new Client("Дарина", "Переказати кошти"));
        //
        // Thread thread1 = new Thread(() => AddClient(clients1));
        // Thread thread2 = new Thread(() => AddClient(clients2));
        // Thread thread3 = new Thread(ProcessClients);
        //
        // thread1.Start();
        // thread2.Start();
        //
        // thread1.Join();
        // thread2.Join();
        //
        // thread3.Start();
        // thread3.Join();
        //
        
        //Task2

        List<string> actions1 = new List<string>()
        {
            "Відрити документ",
            "Закрити документ",
            "Надіслати документ"
        };
        List<string> actions2 = new List<string>()
        {
            "Зберегти документ",
            "Видалити документ",
            "Відформатувати документ"
        };
        
        Thread thread1 = new Thread(() => AddAction(actions1));
        Thread thread2 = new Thread(() => AddAction(actions2));
        Thread thread3 = new Thread(CancelLastAction);
        
        thread1.Start();
        thread2.Start();
        
        thread1.Join();
        thread2.Join();
        
        thread3.Start();
        thread3.Join();
    }
}