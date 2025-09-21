// ReSharper disable All
namespace MethodHidingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example 1:
            // `Dog` declared as `Dog`.
            Dog dog = new Dog();
        
            Console.Write("Calling MakeSound() on dog: ");
            dog.MakeSound();            // Calls Dog version (hides base).
            
            // Example 2:
            // `Dog` declared as `Animal`.
            Animal polymorphicDog = new Dog();
        
            Console.Write("Calling MakeSound() on polymorphicDog: ");
            polymorphicDog.MakeSound(); // Calls Animal version.
            
            // Example 3:
            // Downcasting polymorphicDog (we tell C# our polymorphicDog is actually of type `Dog`).
            // Note this will throw an exception if polymorphicDog would not actually be of type `Dog`.
            Dog upcastedDog = (Dog)polymorphicDog;
            
            Console.Write("Calling MakeSound() on upcastedDog: ");
            upcastedDog.MakeSound();    // Calls Animal version.

            // Explanation:
            // Because Dog uses 'new' instead of 'override',
            // the method in Dog *hides* the one in Animal.
            // It does NOT replace it when called via an Animal reference.
            
            // More on casts:
            // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/casting-and-type-conversions
        }
    }

    class Animal
    {
        public void MakeSound()
        {
            Console.WriteLine("Some generic animal sound...");
        }
    }

    class Dog : Animal
    {
        // The 'new' keyword hides the base method instead of overriding it.
        public new void MakeSound()
        {
            Console.WriteLine("Bark! Bark!");
        }
    }
}
