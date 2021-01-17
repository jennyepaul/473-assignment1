/* CSCI473 
 * Assignment 1
 * TEAM: JennyCasey
 * Contributors: Jennifer Paul (z1878099) and Casey McDermott (ID HERE)
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace JennyCasey_Assign1
{
    
    class Item
    {
        //constant to be used
        private static uint MAX_ILVL = 360;
        private static uint MAX_PRIMARY = 200;
        private static uint MAX_STAMINA = 275;
        private static uint MAX_LEVEL = 60;

        //private attributes of Item class
        private readonly uint _id;
        private string name;
        private ItemType type;
        private uint ilvl;
        private uint primary;
        private uint stamina;
        private uint requirement;
        private string flavor;

        //default constructor
        public Item()
        {
            _id = 0;
            name = "";
            type = 0;
            ilvl = 0;
            primary = 0;
            stamina = 0;
            requirement = 0;
            flavor = "";   
        }

        //overloaded constructor to assign initial values to all attributes
        public Item(uint _id, string name, ItemType type, uint ilvl, uint primary, uint stamina, uint requirement, string flavor)
        {
            this._id = _id;
            this.name = name;
            this.type = type;
            this.ilvl = ilvl;
            this.primary = primary;
            this.stamina = stamina;
            this.requirement = requirement;
            this.flavor = flavor;
        }
        public uint ID
        {
            //only a getter, since only readonly
            get
            {
                return _id;
            }
        }

        public string Name
        {
            //free read/write access so both a setter and getter
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public ItemType Type
        {
            //free read/write access so both getter and setter
            get
            {
                //might need subscript here to get specific type?
                return type;
            }
            set
            {
                /*
                if(value < 0 || value > 12)
                {
                    throw new Exception("Valid range is [0,12]");
                }
                */
               
                type = value;
            }
        }

        public uint Ilvl
        {
            //free read/write access so getter and setters
            get
            {
                return ilvl;
            }
            set
            {
                //put a check in here for valid range
                ilvl = value;
            }
        }

        public uint Primary
        {
            //read and write access so getter and setter
            get
            {
                return primary;
            }
            set
            {
                primary = value;
            }
        }

        public uint Stamina
        {
            //read and write access so getter and setter
            get
            {
                return stamina;
            }
            set
            {
                stamina = value;
            }
        }

        public uint Requirement
        {
            //read and write access, so getter and setter
            get
            {
                return requirement;
            }
            set
            {
                requirement = value;
            }
        }

        public string Flavor
        {
            //read and write access, so getter and setter
            get
            {
                return flavor;
            }
            set
            {
                flavor = value;
            }
        }
    }
}
