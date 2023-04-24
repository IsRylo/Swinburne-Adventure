using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        // Override to include the Player's name, description, and
        // details of the items in the Player's inventory
        public override string FullDescription
        {
            get
            {
                return $"You are {Name}, {base.FullDescription}.\nYou are carrying:\n{Inventory.ItemList}";
            }
        }

        public Player(string name, string desc) : 
            base(new string[] {"me", "inventory"}, name, desc)
        {
            _inventory = new Inventory();
        }

        // Finds a GameObject somewhere around the player. At this stage that 
        // includes the player themselves, or an item the player has in their 
        // inventory
        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;
            return _inventory.Fetch(id);
        }
    }
}