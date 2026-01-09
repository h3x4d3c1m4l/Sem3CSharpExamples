using System.Text.Json;

class Program
{
    static async Task Main()
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.UserAgent.ParseAdd("Demo App");

        var url = "https://api.github.com/search/repositories?q=language:csharp&per_page=30";

        // Start spinner with option to cancel
        using var cts = new CancellationTokenSource();
        var spinnerTask = ShowSpinnerAsync("Loading top 30 C# repos from GitHub", cts.Token);

        // Actual async I/O work
        var response = await client.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();

        // await Task.Delay(5000); // Optional: Simulate longer delay for demonstration

        // Stop spinner using cancellation token
        cts.Cancel();
        await spinnerTask;

        // Parse and present results
        using var doc = JsonDocument.Parse(json);
        var items = doc.RootElement.GetProperty("items");

        Console.WriteLine("Top 30 C# repositories on GitHub:\n");

        foreach (var repo in items.EnumerateArray())
        {
            var name = repo.GetProperty("full_name").GetString();
            Console.WriteLine(name);
        }
    }

    static async Task ShowSpinnerAsync(string message, CancellationToken token)
    {
        var spinner = new[] { '|', '/', '-', '\\' };
        int index = 0;

        while (!token.IsCancellationRequested)
        {
            Console.Write($"\r{message} {spinner[index++ % spinner.Length]}");
            await Task.Delay(100);
        }

        Console.WriteLine("\n");
    }
}
