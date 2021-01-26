/* CSCI473 
 * Assignment 1
 * TEAM: JennyCasey
 * Contributors: Jennifer Paul (z1878099) and Casey McDermott (ID HERE)
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace JennyCasey_Assign1
{
    
    public class Item : IComparable<Item>
    {
        //constant to be used
        private static uint MAX_ILVL = 360;
        private static uint MAX_PRIMARY = 200;
        private static uint MAX_STAMINA = 275;
        //private static uint MAX_LEVEL = 60;

        //private attributes of Item class
        private readonly uint _id;   
        private string name;         
        private ItemType type;       
        private uint ilvl;           
        private uint primary;           //stat on item, benefit it gives
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
            set {   }
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
                
                //if(value > 0 && value < 12)
                //{
                    type = value;

               // }

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
                if(value > 0 && value < MAX_ILVL)
                {
                    ilvl = value;
                }
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
                if(value > 0 && value < MAX_PRIMARY)
                {
                    primary = value;
                }
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
                if(value > 0 && value < MAX_STAMINA)
                {
                    stamina = value;
                }
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

        public Dictionary<uint, Item> BuildItemTable()
        {
            string itemRecord;
            var items = new Dictionary<uint, Item>();

            using (StreamReader inFile = new StreamReader("../../../equipment.txt"))
            {
                while ((itemRecord = inFile.ReadLine()) != null)
                {
                    //the following are variables to hold the parsed values of the various object attributes
                    uint parsedID;
                    uint parsedILVL;
                    uint parsedPRIM;
                    uint parsedSTAMINA;
                    uint parsedREQUIREMENT;
                    ItemType parsedType;

                    //split the record line from the text file based on tab and store into string array
                    string[] parameter = itemRecord.Split('\t');

                    //TryParse-ing each string to the proper data type to catch any possible exceptions
                    uint.TryParse(parameter[0], out parsedID);
                    Enum.TryParse(parameter[2], out parsedType);
                    uint.TryParse(parameter[3], out parsedILVL);
                    uint.TryParse(parameter[4], out parsedPRIM);
                    uint.TryParse(parameter[5], out parsedSTAMINA);
                    uint.TryParse(parameter[6], out parsedREQUIREMENT);

                    //constructing new object of the class
                    Item newItem = new Item(parsedID, parameter[1], parsedType, parsedILVL, parsedPRIM, parsedSTAMINA, parsedREQUIREMENT, parameter[7]);

                    //add the new item to the dictionary
                    items.Add(parsedID, newItem);
                }
            }

            return items;
        }
        public void PrintAllItems(Dictionary<uint, Item> dictionary)
        {
            //iterate through dictionary and print the key (ID of item) and the value (attributes of item object)
            foreach (var item in dictionary)
                Console.WriteLine("{0}", item.Value);
        }

        //sort by name for items
        public int CompareTo(Item alpha)
        {
            //if null, we can't compare so throw an exception
            if (alpha == null)
            {
                throw new ArgumentNullException();
            }
            //else it isn't null so let's compare and sort by name
            else
                return this.Name.CompareTo(alpha);
        }

        public void SortItemNames (Dictionary<uint, Item> dictionary)
        {
            //create SortedSet, fill it with the name of items, then print out
            //the sorted names
            SortedSet<string> sortedItems = new SortedSet<string>();
            foreach (var nameOfItem in dictionary)
            {
                sortedItems.Add(nameOfItem.Value.Name);
            }
            foreach (var i in sortedItems)
            {
                Console.WriteLine(i);
            }
        }

        //overridden ToString() method
        public override string ToString()
        {    
 
            return "(" + this.Type + ") " + this.Name + " |" + this.Ilvl + "| --" + this.Requirement + "--" + "\n\t" + this.Flavor;
            
        }
    }
}
