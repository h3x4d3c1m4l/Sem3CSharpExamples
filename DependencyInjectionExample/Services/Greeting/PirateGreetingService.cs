using DependencyInjectionExample.Services.Logging;

namespace DependencyInjectionExample.Services.Greeting;

/// <summary>
/// Een piraten-implementatie van de IGreetingService.
/// </summary>
public class PirateGreetingService : IGreetingService
{
    private ILoggingService _loggingService;
    
    /// <summary>
    /// Construct een PirateGreetingService.
    /// Let op dat de parameters via DI worden ingebracht, vanuit de ServiceCollection.
    /// </summary>
    /// <param name="loggingService">De ILoggingService zoals geregistreerd in de ServiceCollection</param>
    public PirateGreetingService(ILoggingService loggingService)
    {
        _loggingService = loggingService;
    }

    public string Greet(string name)
    {
        _loggingService.LogLine($"PirateGreetingService has been asked to greet {name} in pirate style!");
        return $"Ahoy, {name}!";
    }
}
