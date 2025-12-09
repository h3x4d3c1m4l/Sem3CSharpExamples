namespace DependencyInjectionExample.Services.Greeting;

/// <summary>
/// Een interface welke een eenvoudige groet-functie definieert.
/// </summary>
public interface IGreetingService
{
    string Greet(string name);
}
