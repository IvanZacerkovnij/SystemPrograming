using System.Runtime.InteropServices;

namespace Homework2;

class Program
{
    [DllImport("libmylib.dylib", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr CreatePointManager();
    [DllImport("libmylib.dylib", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeletePointManager(IntPtr pointmanager);
    [DllImport("libmylib.dylib", CallingConvention = CallingConvention.Cdecl)]
    public static extern void AddPoint(IntPtr pointmanager, int x, int y);
    [DllImport("libmylib.dylib", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RemovePoint(IntPtr pointmanager, int index);
    [DllImport("libmylib.dylib", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetPoint(IntPtr pointmanager, int index, out int x, out int y);
    [DllImport("libmylib.dylib", CallingConvention = CallingConvention.Cdecl)]
    public static extern int Count(IntPtr pointmanager);
    
    static void Main(string[] args)
    {
        var pointmanager = CreatePointManager();
        
        AddPoint(pointmanager, 10, 10);

        int x0;
        int y0;
        
        GetPoint(pointmanager, 0, out x0, out y0);
        
        Console.WriteLine($"Point 0: {x0} , {y0}");
        
        RemovePoint(pointmanager, 0);
        RemovePoint(pointmanager, 0);
        
        DeletePointManager(pointmanager);
    }
}