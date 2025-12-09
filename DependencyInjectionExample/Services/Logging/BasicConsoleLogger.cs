namespace DependencyInjectionExample.Services.Logging;

/// <summary>
/// Een simpele implementatie van de ILoggingService.
/// </summary>
public class BasicConsoleLogger : ILoggingService
{
    public void LogLine(string message)
    {
        Console.WriteLine(message);
    }
}
