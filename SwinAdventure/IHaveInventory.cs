using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public interface IHaveInventory
    {
        public string Name
        {
            get;
        }
        public GameObject? Locate(string id);
    }
}