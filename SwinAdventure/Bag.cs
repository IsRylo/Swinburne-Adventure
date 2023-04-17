using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwinAdventure
{
    // The bag uses the composite pattern
    // Application: when a class has property and methods of 
    //  a collection of object, but is still treated as an derivate of the same class 
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory;

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public override string FullDescription
        {
            get
            {
                return $"In the {Name}, you can see:\n{Inventory.ItemList}";
            }
        }

        public GameObject? Locate(string id)
        {
            if (AreYou(id)) return this;
            else return Inventory.Fetch(id);
        }

        public Bag(string[] idents, string name, string desc) : base(idents, name, desc)
        {
            _inventory = new Inventory();
        }
    }
}