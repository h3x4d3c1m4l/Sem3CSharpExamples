using Microsoft.Extensions.DependencyInjection;
using DependencyInjectionExample.Services.Greeting;
using DependencyInjectionExample.Services.InstanceCounting;
using DependencyInjectionExample.Services.Logging;

namespace DependencyInjectionExample;

/// <summary>
/// De daadwerkelijke applicatie, zoals je voorheen waarschijnlijk in Program had staan.
/// </summary>
public class App
{
    private ILoggingService _loggingService;
    private IGreetingService _greetingService;

    private IServiceProvider _serviceProvider;

    /// <summary>
    /// Construct een App.
    /// Let op dat de parameters via DI worden ingebracht, vanuit de ServiceCollection.
    /// </summary>
    /// <param name="loggingService">De ILoggingService zoals geregistreerd in de ServiceCollection</param>
    /// <param name="greetingService">De IGreetingService zoals geregistreerd in de ServiceCollection</param>
    /// <param name="serviceProvider">De service provider *zelf* als alternatief om service op te vragen</param>
    public App(ILoggingService loggingService, IGreetingService greetingService, IServiceProvider serviceProvider)
    {
        _loggingService = loggingService;
        _greetingService = greetingService;
        _serviceProvider = serviceProvider;
    }
    
    /// <summary>
    /// Hier komt de code die je voorheen waarschijnlijk in Main had staan.
    /// </summary>
    public void Run()
    {
        _loggingService.LogLine("The DEMO is started.");

        _greetingService.Greet("SampleName");

        _loggingService.LogLine($"_loggingService is of type: {_loggingService.GetType().Name}");
        _loggingService.LogLine($"_greetingService is of type: {_greetingService.GetType().Name}");
        
        // We doen dit twee keer, zodat je ziet dat de static counter verhoogd wordt. Zie console output.
        // Dit is het bewijs dat er nu meerdere instanties gemaakt zijn (Transient vs. Singleton).
        _serviceProvider.GetRequiredService<IInstanceCounter>().PrintInstanceCount();
        _serviceProvider.GetRequiredService<IInstanceCounter>().PrintInstanceCount();
        
        _loggingService.LogLine("The DEMO has ended.");
    }
}
