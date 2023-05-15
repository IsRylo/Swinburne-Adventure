using System;

namespace SwinAdventure
{
    public class Program
    {
        static void Main(string[] args)
        {   
            string[] text;
            Command command = new LookCommand();;

            Console.WriteLine("Welcome to Swin Adventure!");
            Console.WriteLine("---------------------------");

            // Get the player's naem and description from the user, and
            // use these details to create a Player object.
            Console.Write("Please enter player name: ");
            string name = Console.ReadLine()!;
            Console.Write("Please enter player description: ");
            string description = Console.ReadLine()!;

            Player p1 = new Player(name, description);

            // // Create two items and add them to the player's inventory
            p1.Inventory.Put(new Item(new string[] {"sword", "blade"}, "a bronze sword", "A starter weapon"));
            p1.Inventory.Put(new Item(new string[] {"shovel", "spade"}, "a shovel", "This is a might fine ... "));

            // Create a bag and add it to the bag 
            Bag b1 = new Bag(new string[]{"b1"}, "a bag", "Bag containing items");
            p1.Inventory.Put(b1);

            // Create another item and add it to the bag
            b1.Inventory.Put(new Item(new string[] {"gem", "gemstone"}, "a gem", "red and shiny"));

            Console.WriteLine("Welcome to Swin Adventure!\nYou have arrived in the Hallway");
            // Loop reading commands from the user
            // and getting the look command to execute them.
            while (true)
            {
                Console.Write("Command -> ");
                text = Console.ReadLine()!.ToLower().Split(" ");
                    
                switch (text[0])
                {
                    case "look":
                        Console.WriteLine(command.Execute(p1, text));
                        break;
                    case "quit":
                        return;
                    default:
                        Console.WriteLine("Command not recognized");
                        break;
                }
            } 
        }
    }
}