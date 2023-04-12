using System;

namespace SwinAdventure
{
    public class Program
    {
        static void Main(string[] args)
        {
            Player p = new Player("Loysing", "A new Programmer");
            p.Inventory.Put(new Item(new string[] {"sword", "blade"}, "a bronze sword", "A starter weapon"));
            p.Inventory.Put(new Item(new string[] {"shovel", "spade"}, "a shovel", "This is a might fine ... "));
            Console.WriteLine(p.Inventory.ItemList);
        }
    }
}