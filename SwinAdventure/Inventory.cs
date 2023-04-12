using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;

        public string ItemList
        {
            get
            {
                string list = "";
                foreach(Item itm in _items)
                    list += "\t" + itm.ShortDescription + "\n";
                return list;
            }
        }
        
        public Inventory() 
        {
            _items = new List<Item>();
        }

        // If the inventory has the item
        public bool HasItem(string id) 
        {
            foreach(Item itm in _items)
                if (itm.AreYou(id)) return true;
            return false;
        }

        // Items can be added using the Put command
        public void Put(Item itm) 
        {
            _items.Add(itm);
        }

        // or removed by id using Take
        public Item? Take(String id)
        {
            Item? chosenItem = Fetch(id);
            if (chosenItem != null)
                _items.Remove(chosenItem);
            return chosenItem;
        }

        // Locates an item by id (using AreYou) and returns it
        public Item? Fetch(String id) // Added ? to declare as nullable
        {
            foreach(Item itm in _items)
                if (itm.AreYou(id)) return itm;
            return null;
        }
    }
}