namespace DependencyInjectionExample.Services.Logging;

/// <summary>
/// Een interface welke een eenvoudige log line-functie definieert.
/// </summary>
public interface ILoggingService
{
    void LogLine(string message);
}
