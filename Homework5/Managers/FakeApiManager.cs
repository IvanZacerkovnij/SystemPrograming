using System.Net.Http.Json;
using Homework5.Models;

namespace Homework5.Managers;

public class FakeApiManager(HttpClient _client) : IDisposable
{

    private static void WaitInMenu()
    {
        Console.Clear();
        var counter = 0;
        for (int i = 0; i < 50; i++)
        {
            char symbol;
            Console.Clear();
            Console.Write("[");
            for (int j = 0; j < 50; j++)
            {
                if (j <= i)
                {
                    symbol = '■';
                }
                else
                {
                    symbol = '-';
                }

                Console.Write(symbol);
            }
            counter = i * 100 / 50;
            Console.Write($"] {counter}%");
            Thread.Sleep(200);
        }
        Console.Clear();
        Console.WriteLine("Completed.\nPress any key to continue...");
        Console.ReadKey();
    }
    
    public async Task<List<Post>?> GetAllPost()
    {
        WaitInMenu();
        return await _client.GetFromJsonAsync<List<Post>>("posts");
    }

    public async Task<Post?> GetPostById(int id)
    {
        WaitInMenu();
        return await _client.GetFromJsonAsync<Post>($"posts/{id}");
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}