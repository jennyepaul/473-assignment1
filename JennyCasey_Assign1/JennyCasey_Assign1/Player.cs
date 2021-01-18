/* CSCI 473
 * Assignment 1
 * TEAM: JennyCasey
 * Contributors: Jennifer Paul (z1878099) and Casey McDermott (z1878096) 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JennyCasey_Assign1
{
    public class Player
    {
        //constants for program
        private static uint MAX_LEVEL = 60;
        private static uint GEAR_SLOTS = 14;
        private static uint MAX_INVENTORY_SIZE = 20;

        private readonly uint id;
        private readonly string name;
        private readonly string race;
        private uint level;
        private uint exp;
        private uint guildId;
        private uint[] gear;
        private List<uint> inventory;

        /*
        string[] gear =
        {
            "Newbie's Helmet", "Newbie's Cloak", "Newbie's Raiment",
            "Newbie's Gloves", "Newbie's Trousers", "Newbie's Sandals",
            "Slacker", "Nebula's Pauldrons", "Dread Pirate Nebula's Cloak",
            "Nebula's Resentment", "Nebula's Wristgaurds", "Nebula's Fury",
            "The Spire", "Nebula's Legguards", "Nebula's Stompers", "Gamora's Acceptance",
            "Gamora's Love", "Infinity Gauntlet"
        };
        */
        // default constructor 
        public Player()
        {
            id = 0;
            name = "";
            race = "";
            level = 0;
            exp = 0;
            guildId = 0;
            //gear = new uint[];
            //inventory = 0;
        }


        //alternate constructor
        public Player(uint id, string name, string race, uint level, uint exp, uint guildId, uint[] gear, List<uint> inventory)
        {
            this.id = id;
            this.name = name;
            this.race = race;
            this.level = level;
            this.exp = exp;
            this.guildId = guildId;
            this.gear = gear;
            this.inventory = inventory;
        }

        //only a getter, since only readonly
        public uint ID
        {
            get
            {
                return id;
            }
        }

        //only a getter, since only readonly
        public string Name
        {
            get
            {
                return name;
            }
        }

        //only a getter, since only readonly
        public string Race
        {
            get
            {
                return race;
            }
        }

        public uint Level
        {
            //free read/write acess so getter and setters
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }

        public uint Exp
        {
            //free read/write acess so getter and setters
            get
            {
                return exp;
            }
            set
            {
                if (exp < MAX_LEVEL)
                {
                    //only incremnt exp if it does not exceed MAX_LEVEL
                    exp += value;
                }
            }
        }

        public uint GuildID
        {
            //free read/write acess so getter and setters
            get
            {
                return guildId;
            }
            set
            {
                guildId = value;
            }
        }

        public int Length => gear.Length;

        //declaring the indexer
        //gear array with throw exception if out of range
        public string this[int index]
        {
            get => gear[index];
            set => gear[index] = value;
        }

        public List<uint> Inventory
        {
            //free read/write acess so getter and setters
            get
            {
                return inventory;
            }
            set
            {
                inventory = value;
            }
        }

        public void Equipgear(uint newGearID)
        {
            //determine if this is a valid piece of gear at all

            //if the players level matches or exceeds the level requirement
            //throw a new exception with an appropriate error message as the arguement 

            //if the tests above are passed, place that ID value into the correct element of your gear array
        }

        public void UnequipGear(int gearSlot)
        {
            //need to evaluate if the indicated index of the gearSlot (int gearSlot) in the gear array is already occupied
            //if it is occupied, place the item there (At that index) into the player's inventory (use a method ot do this)
            //throw an exception if the number of elements in the inventory is the same or greater than the constant that represents
            //the max size of inventory

        }
        public int LevelUp()
        {
            //just putting this here so we don't get error, but this method should handle the leveling up and return the current level of the player
            int level = 0; //??
            return level;
        }

        public void PrintGearList()
        {
            //prints players name, level, followed by list of equipped gear (or an empty message if that index value 
            //is equal to 0 or null
        }

        public void PrintPlayerList()
        {
            //print name, race, level, guild

        }

    }
}