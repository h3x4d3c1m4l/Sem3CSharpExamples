// ReSharper disable All
namespace AbstractClassDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Animal genericAnimal = new Animal(); // Not allowed: Animal is abstract.

            Dog dog = new Dog();
            Cat cat = new Cat();

            Console.WriteLine("Dog makes a sound:");
            dog.MakeSound();

            Console.WriteLine("\nCat makes a sound:");
            cat.MakeSound();
        }
    }

    abstract class Animal
    {
        // Abstract method: subclasses MUST implement this.
        public abstract void MakeSound();

        // Non-abstract method: subclasses can call this to reuse behavior.
        public void Breathe()
        {
            Console.WriteLine("Inhale... Exhale...");
        }
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            // Call base method for shared behavior.
            base.Breathe();
            Console.WriteLine("Bark! Bark!");
        }
    }

    class Cat : Animal
    {
        public override void MakeSound()
        {
            // Reuse base behavior.
            base.Breathe();
            Console.WriteLine("Meow!");
        }
    }    
}
