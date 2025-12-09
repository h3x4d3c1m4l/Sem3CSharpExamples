using DependencyInjectionExample.Services.Logging;

namespace DependencyInjectionExample.Services.InstanceCounting;

public class BasicInstanceCounter : IInstanceCounter
{
    private ILoggingService _loggingService;

    private static int _instanceCount = 0; // Static! Anders zien we hem niet verhoogd worden per aangemaakt instance.
    
    public BasicInstanceCounter(ILoggingService loggingService)
    {
        _loggingService = loggingService;
        _instanceCount++;
    }

    public void PrintInstanceCount()
    {
        _loggingService.LogLine($"BasicInstanceCounter has been instanced {_instanceCount} times!");
    }
}
