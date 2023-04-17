using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public abstract class Command : IdentifiableObject
    {
        protected Command(string[] idents) : base(idents) {}

        public abstract string Execute(Player p, string[] text);
    }
}