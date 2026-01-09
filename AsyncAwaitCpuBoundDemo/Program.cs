class Program
{
    const int LIMIT = 10_000_000; // Takes a ~few seconds to compute

    static async Task Main()
    {
        // Start spinner with option to cancel
        using var cts = new CancellationTokenSource();
        var spinnerTask = ShowSpinnerAsync($"Counting primes with limit {LIMIT}", cts.Token);

        // Actual CPU-bound work offloaded to thread pool
        int primeCount = await Task.Run(() =>
        {
            return CountPrimes(LIMIT);
        });

        // Stop spinner using cancellation token
        cts.Cancel();
        await spinnerTask;

        // Present results
        Console.WriteLine($"Found {primeCount} prime numbers up to {LIMIT}");
    }

    static int CountPrimes(int max)
    {
        int count = 0;

        for (int i = 2; i <= max; i++)
        {
            if (IsPrime(i))
                count++;
        }

        return count;
    }

    static bool IsPrime(int number)
    {
        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
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
