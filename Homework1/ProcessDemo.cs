using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;

namespace Homework1;

public class ProcessDemo
{
    private Process[] _processes => Process.GetProcesses();
    public async Task Run()
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.Clear();
            Console.WriteLine("=== ProcessDemo ===");
            foreach (var item in Enum.GetValues(typeof(Menu)))
            {
                Console.WriteLine($"{(int)item} - {item}");
            } 
            keyInfo = Console.ReadKey();
            switch(keyInfo.KeyChar)
            {
                case '0': break;
                case '1': 
                    ShowAllProcessesFiltered(); 
                    break;
                case '2': 
                    ShowAllProcesses();
                    break;
                case '3':
                    KillProcess();
                    break;
                case '4':
                    CreateProcess();
                    break;
                case '5':
                    OpenDouUa();
                    break;
                default: 
                    Console.WriteLine("Unknown operation");
                    break;
            }
        } while (keyInfo.KeyChar != '0');

        await SaveCurrentProcesses();
    }

    private async Task SaveCurrentProcesses()
    {
        if (!Directory.Exists("../../../Logs"))
        {
            Directory.CreateDirectory("../../../Logs");
        }
        string fileName = $"Log{DateTime.Now}";
        File.Create($"../../../Logs/{fileName}.txt").Dispose();
        
        var content = string.Join("\n", _processes.Select(p => p.ProcessName));
        await File.WriteAllTextAsync($"../../../Logs/{fileName}.txt", content);
    }

    private void OpenDouUa()
    {
        Console.Clear();
        Process.Start("open","https://dou.ua");
        Console.ReadKey();
    }
    private void CreateProcess()
    {
        Console.Clear();
        Console.Write("Enter program name: ");
        string programName = Console.ReadLine();
        
        var processes = Process.GetProcessesByName(programName);
        if (processes.Length != 0)
        {
            Console.WriteLine($"Process is already running");
        }
        try
        {
            if (programName != null)
            {
                Process.Start("open",$"-a \"{programName}\"");
                Console.ReadKey();
            }
        } catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
            Console.ReadKey();
        }
    }

    private void ShowAllProcessesFiltered()
    { 
       Console.Clear();
       var uniqueNames = _processes.GroupBy(x => x.ProcessName);
       foreach (var unique in uniqueNames)
       {
           
           Console.WriteLine($"{unique.Key}: {unique.Count()}");
       }
       Console.ReadKey();
    }

    private void ShowAllProcesses()
    {
        Console.Clear();
        foreach (var process in _processes)
        {
            Console.WriteLine($"PID: {process.Id} : {process.ProcessName}");
        }
        Console.ReadKey();
    }

    private void KillProcess()
    {
        Console.Clear();
        Console.WriteLine("Choose how to kill process: ");
        Console.WriteLine("1. Kill by Id");
        Console.WriteLine("2. Kill by Name");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        Console.Clear();
        switch (keyInfo.KeyChar)
        {
            case '1':
                try
                {
                    Console.Write("Enter PID ");
                    int pid = int.Parse(Console.ReadLine());
                    var process = Process.GetProcessById(pid);
                    process.Kill();
                    Console.WriteLine($"{process.ProcessName} - Killed");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Console.ReadKey();
                }
                break;
            case '2':
                try
                {
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    if (name != null)
                    {
                        var processes = Process.GetProcessesByName(name);
                        foreach (var process in processes)
                        {
                            process.Kill();
                        }
                        Console.WriteLine($"Process {name}- killed");
                        Console.ReadKey();
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Console.ReadKey();
                }
                break;
            default:
                Console.WriteLine("Unknown operation");
                Console.ReadKey();
                break;
        }
    }
}