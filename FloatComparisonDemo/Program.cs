// ReSharper disable All
namespace FloatComparisonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = 0.1 + 0.2;
            double number2 = 0.3;
        
            // Floating-point numbers are not always stored with perfect accuracy.
            // The result of 0.1 + 0.2 is actually something like 0.30000000000000004,
            // not exactly 0.3.
        
            // Direct comparison (==) often fails with floating-point numbers.
            Console.WriteLine($"Are number1 and number2 exactly equal? {number1 == number2}");
        
            // A common solution: compare numbers using a small tolerance (epsilon).
            // If the difference is smaller than epsilon, we treat them as "equal".
            const double EPSILON = 0.000001;
            Console.WriteLine($"Are number1 and number2 equal within tolerance? {Math.Abs(number1 - number2) < EPSILON}");
        
            // Alternatives to using epsilon:
            // - Use `decimal` if you need precise decimal values (e.g., financial calculations),
            //   but only when the numbers you work with can be represented exactly.
            // - Use integers to represent values like money (e.g., store amounts in cents instead of euros).
        }
    }   
}
