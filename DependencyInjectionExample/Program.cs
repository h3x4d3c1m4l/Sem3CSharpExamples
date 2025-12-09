using DependencyInjectionExample.Services.Logging;
using Microsoft.Extensions.DependencyInjection;
using DependencyInjectionExample.Services.Greeting;
using DependencyInjectionExample.Services.InstanceCounting;

namespace DependencyInjectionExample;

static class Program
{
    /// <summary>
    /// Startpunt van de dependency injection demo.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        // We gebruiken de officiele ServiceCollection class van Microsoft .NET. Hiermee kun SL en DI doen.
        // Hiervoor dien je de package te installeren in je eigen project, dat kan met dit command in je terminal:
        // `dotnet add package Microsoft.Extensions.DependencyInjection`
        // Lees hier meer: https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection

        var services = new ServiceCollection();

        // Register services: Dit zijn:
        //   - Singleton services, de services die eenmaal geinstantieerd worden. Hiervoor kun je denken aan:
        //   - Transient services, de services die steeds opnieuw geinstantieerd worden.
        //   - Je app zelf, dit wordt het nieuwe startpunt van je applicatie in plaats van Main.
        // Er is veel meer mogelijk met ServiceCollection, maar dat is voor nu out of scope.
        
        // Services zijn bijvoorbeeld:
        //   - Database clients (MySQL, SQLite, etc.)
        //   - API clients (REST API, GraphQL API clients, GitHub API client, etc.)
        //   - Repositories (een laag bovenop je database client of API client, of een repository voor een JSON of CSV file)
        // Of een service singleton of transient moet zijn, kun je laten af hangen van de "state" die erin zit.
        // Vraag je bijvoorbeeld af: Heb ik iedere keer een "schone" instance nodig?

        // Let op dat je ieder type in principe maar 1 keer kunt registreren.
        // Wil je een andere IGreetingService of ILoggingService, dan moet je die uncommenten en de andere commenten.

        //services.AddSingleton<ILoggingService, BasicConsoleLogger>();
        services.AddSingleton<ILoggingService, FancyConsoleLogger>();
        //services.AddSingleton<IGreetingService, BasicGreetingService>();
        services.AddSingleton<IGreetingService, PirateGreetingService>();

        services.AddTransient<IInstanceCounter, BasicInstanceCounter>();
        services.AddTransient<App>();

        // Build service provider: Met de provider kun je de geregistreerde services weer opvragen.
        // Waarom registreren we de App ook? Kijk naar de constructor in App.
        // Daar gebeurt een stukje magie (dependency injection) wat anders niet werkt.
        
        // We demonstreren in App twee manieren om onze 3 services op te vragen:
        //   - Direct opvragen via de constructor
        //   - De IServiceProvider zelf opvragen via de constructor, en via die IServiceProvider de services opvragen

        var provider = services.BuildServiceProvider();
        provider.GetRequiredService<App>().Run();
    }
}
