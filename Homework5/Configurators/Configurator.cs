using Microsoft.Extensions.Configuration;

namespace Homework5.Configurators;

public static class Configurator
{
    public static HttpClient Configure()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        string url = builder["URL:FakeAPI"];
        
        return new HttpClient(){ BaseAddress = new Uri(url) };
    }
}