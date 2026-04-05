using Homework5.Configurators;
using Homework5.Managers;

namespace Homework5;

class Program
{

    static void Main(string[] args)
    {
         using var manager = new FakeApiManager(Configurator.Configure());

         // var posts = manager.GetAllPost().Result;
         // foreach (var post in posts)
         // {
         //     
         //     Console.WriteLine("========================");
         //     Console.WriteLine(post);
         //     Console.WriteLine("========================");
         // }
         var post = manager.GetPostById(5).Result;
         
         Console.WriteLine("========================");
         Console.WriteLine(post);
         Console.WriteLine("========================");
         
    }
}