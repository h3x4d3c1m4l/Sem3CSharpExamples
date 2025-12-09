using DependencyInjectionExample.Services.Logging;

namespace DependencyInjectionExample.Services.Greeting;

/// <summary>
/// Een simpele implementatie van de IGreetingService.
/// </summary>
public class BasicGreetingService : IGreetingService
{
    private ILoggingService _loggingService;
    
    /// <summary>
    /// Construct een BasicGreetingService.
    /// Let op dat de parameters via DI worden ingebracht, vanuit de ServiceCollection.
    /// </summary>
    /// <param name="loggingService">De ILoggingService zoals geregistreerd in de ServiceCollection</param>
    public BasicGreetingService(ILoggingService loggingService)
    {
        _loggingService = loggingService;
    }
    
    public string Greet(string name)
    {
        _loggingService.LogLine($"BasicGreetingService has been asked to greet {name}");
        return $"Hello, {name}";
    }
}
