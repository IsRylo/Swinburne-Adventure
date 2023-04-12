using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _name;
        private string _description;

        public string Name
        {
            get
            {
                return _name;
            }
        }

        // Returns description made up of name and the first id of the gameobject
        public string ShortDescription
        {
            get
            {
                return $"{Name} ({FirstId})";
            }

            set
            {
                _description = value;
            }
        }

        // By default returns description, but will be changed by 
        // child classes to include related items 
        public virtual string FullDescription 
        { 
            get
            {
                return _description;
            }
        }

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }
    }
}