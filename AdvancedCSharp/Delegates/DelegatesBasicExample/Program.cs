using System.ComponentModel.DataAnnotations;

class Program
{
    delegate void LogDel(string text);
    static void Main(string[] args)
    {
        Log log = new Log();
        //LogDel logDel = new LogDel(log.LogTextToScreen);

        LogDel LogTextToScreenDel, LogTextToFileDel;

        LogTextToScreenDel = new LogDel(log.LogTextToScreen);
        LogTextToFileDel = new LogDel(log.LogTextToFile);
        //Multi Cast Delegate
        LogDel multiLogDel = LogTextToScreenDel + LogTextToFileDel;


        Console.WriteLine("Please enter your name");

        var name = Console.ReadLine();
        //Invoking multicast Delegate
        multiLogDel(name);

        //pasing Delegates as argument
        LogText(multiLogDel,name);

        Console.ReadKey();
    }

    static void LogText(LogDel logDel, string text)
    {
        logDel(text);
    }
    static void LogTextToScreen(string text)
    {
        Console.WriteLine($"{DateTime.Now}: {text}");
    }

    static void LogTextToFile(string text)
    {
        using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt")))
        {
            sw.WriteLine($"{DateTime.Now}: {text}");
        }
    }
}

public class Log
{
    public void LogTextToScreen(string text)
    {
        Console.WriteLine($"{DateTime.Now}: {text}");
    }

    public void LogTextToFile(string text)
    {
        using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt")))
        {
            sw.WriteLine($"{DateTime.Now}: {text}");
        }
    }
}