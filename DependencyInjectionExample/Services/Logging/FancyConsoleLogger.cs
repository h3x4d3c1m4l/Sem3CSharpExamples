namespace DependencyInjectionExample.Services.Logging;

/// <summary>
/// Een fancy implementatie met kleurtjes van de ILoggingService.
/// </summary>
public class FancyConsoleLogger : ILoggingService
{
    private const string StartBold = "\e[1m";
    private const string EndBold = "\e[0m";
    private const string StartGreen = "\e[32m";
    private const string EndGreen = "\e[0m";
    
    public void LogLine(string message)
    {
        Console.WriteLine($"{StartBold}MESSAGE{EndBold}: {StartGreen}{message}{EndGreen}");
    }
}
