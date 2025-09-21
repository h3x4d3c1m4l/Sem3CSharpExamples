// ReSharper disable All
namespace MethodOverrideDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal genericAnimal = new Animal();
            Dog dog = new Dog();
            Animal polymorphicDog = new Dog();
        
            Console.Write("Calling MakeSound() on Animal instance: ");
            genericAnimal.MakeSound();  // Calls Animal version
        
            Console.Write("Calling MakeSound() on Dog instance: ");
            dog.MakeSound();            // Calls Dog version
        
            Console.Write("\alling MakeSound() on Dog instance, but referenced as Animal: ");
            polymorphicDog.MakeSound(); // Calls Dog version (thanks to override)
        
            // Because Dog overrides the virtual method in Animal,
            // the Dog version replaces the Animal version in polymorphic calls.
        }
    }

    class Animal
    {
        // Marking the method as virtual allows it to be overridden in subclasses.
        public virtual void MakeSound()
        {
            Console.WriteLine("Some generic animal sound...");
        }
    }

    class Dog : Animal
    {
        // The 'override' keyword replaces the base version in polymorphic calls.
        public override void MakeSound()
        {
            Console.WriteLine("Bark! Bark!");
        }
    }    
}
