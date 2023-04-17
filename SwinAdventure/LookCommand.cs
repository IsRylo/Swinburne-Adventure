using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] {"look"}) {}

        public override string Execute(Player p, string[] text)
        {   
            // Counting number of elements in text
            int count = text.Count();

            if (count != 3 && count != 5) 
                return "I don't know how to look like that";
            if (text[0] != "look") 
                return "Error in look input";

            if (text[1] != "at") 
                return "What do you want to look at?";

            if (count == 3)
                return LookAtIn(text[2], p);

            if (text[3] != "in")
                return "What do you want to look in?";

            IHaveInventory? container = FetchContainer(p, text[4]);

            if (container == null)
                return $"I can't find the {text[4]}";
                
            return LookAtIn(text[2], container);
        }

        private IHaveInventory? FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) != null)
                return container.Locate(thingId)!.FullDescription;
            return $"I can't find the {thingId} in the {container.Name}";
        }
    }
}