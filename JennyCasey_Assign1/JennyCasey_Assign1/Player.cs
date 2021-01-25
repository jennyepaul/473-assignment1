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
using System.IO;

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
        private readonly Race race;
        private uint level;
        private uint exp;
        private uint guildId;
        private uint[] gear;
        private List<uint> inventory;
        // default constructor 
        public Player()
        {
            id = 0;
            name = "";
            race = 0;
            level = 0;
            exp = 0;
            guildId = 0;
            gear = new uint[0];
            inventory = new List<uint>();
        }


        //alternate constructor
        public Player(uint id, string name, Race race, uint level, uint exp, uint guildId, uint[] gear, List<uint> inventory)
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
        public Race Race
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
                //nextLevel would be the current Level * 100
                //set newLevel to Level since we don't want to alter the Level variable
                uint nextLevel = (Level * 1000);
                uint newLevel = Level;

                //if the experience is greater than the value of current level * 1000, we would level up
                //so calculate what the ~possible~ level of the player would be
                if (exp >= nextLevel)
                {
                    exp /= nextLevel;
                    newLevel += exp;

                }

                //if the current level OR the new level after experience is less than MAX_LEVEL
                //we can add the experience
                if ((Level < MAX_LEVEL) || (newLevel < MAX_LEVEL))
                {
                    //only incremnt exp if it does not exceed MAX_LEVEL
                    exp += value;
                }
                else
                {
                    //if its >= MAX_LEVEL then we just return
                    exp += 0;
                    return;
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
        public uint this[int index]
        {
            //get => gear[index];
            //set => gear[index] = value;
            get
            {
                if(index >= 0 && index <= GEAR_SLOTS)
                {
                    return gear[index];

                }
                else 
                {
                    throw new Exception();
}
                }
            set
            {
                gear[index] = value;
            }
            
            
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
            /* if (!gear.Contains(newGearID))
            {
                Console.Write("your gear id does match any in the system");
            }*/

            //if the players level matches or exceeds the level requirement
            //throw a new exception with an appropriate error message as the arguement 

            //if the tests above are passed, place that ID value into the correct element of your gear array
            /*int pos = (gear.Length - 1);
            gear[pos] = newGearID;*/

        }

        public void UnequipGear(int gearSlot)
        {
            List<uint> tempGear = new List<uint>(gear);
            int index;

            //if the gearSlot is less than 10, then the index in the 
            //gear array will be the same
            if (gearSlot <= 9)
            {
                gearSlot += 0;
            }
            //if the gearSlot is 10, the indexes for rings are either 10 or 11
            else if(gearSlot == 10)
            {
                if(gear[10] != 0)
                {
                    gearSlot = 10;
                }
                else
                {
                    gearSlot = 11;
                }
            }
            //if the gearSlot is 11, the indexes for rings are either 11 or 12
            else if (gearSlot == 11)
            {
                if (gear[12] != 0)
                {
                    gearSlot = 12;
                }
                else
                {
                    gearSlot = 13;
                }
            }

            index = gearSlot;
            uint gearToUnequip = gear[index];

            //if the gear at that index is not empty (0) add it to the inventory
            if (gearToUnequip != 0)
            {
            //if the inventory is not full, we can add to it
                if (Inventory.Count <= MAX_INVENTORY_SIZE)
                {

                    //inserting the gear in the inventory
                    Inventory.Add(gear[index]);

                    //removing the gear from the player
                    tempGear.Remove(gearToUnequip);
                    tempGear.Insert(index, 0);
                    //tempGear.
                    //converting back to an array
                    gear = tempGear.ToArray();
                }
                else
                {
                    throw new Exception("Inventory is full");
                }
            }
            else
            {
                Console.WriteLine("No gear item available in that slot to unequip");
            }
        }

        public void LevelUp(uint experience)
        {
            uint nextLevel = (Level * 1000);
            //gaining a level is when experience = (current level * 1000);
            //so if we were at level 3 and wanted to go to level 4 we would need 3000 exp
            if (experience >= nextLevel)
            {
                experience /= nextLevel;
                Level += experience;
            }
            else
            {
                Level += 0;
            }
        }

        //goes through the guild.txt file, splits the records, stores them in variables
        //then stores those in a dictionary so we can search the dictionary via key when we want
        //information about the guilds
        public string FindGuildName(uint ID)
        {
            string guildRecord;
            string name;
            uint uintGuildId;

            var guilds = new Dictionary<uint, string>();

            using (StreamReader inFile = new StreamReader("../../../guilds.txt"))
            {
                while ((guildRecord = inFile.ReadLine()) != null)
                {
                    string[] guildInfo = guildRecord.Split('\t');
                    string guildId = guildInfo[0];
                    string guildName = guildInfo[1];

                    //parse the guild ID to an unsigned integer
                    uint.TryParse(guildId, out uintGuildId);

                    //add the guilds to a dictionary so we can access them 
                    guilds.Add(uintGuildId, guildName);
                }
            }

            foreach (var keyValue in guilds)
            {
                if (keyValue.Key == guildId)
                {
                    name = keyValue.Value;
                    return name;
                }
            }
            return "Not found";
        }
        public uint FindGuildId(string guildNameToFind)
        {
            string guildRecord;
            string name;
            uint uintGuildId;

            var guilds = new Dictionary<uint, string>();

            using (StreamReader inFile = new StreamReader("../../../guilds.txt"))
            {
                while ((guildRecord = inFile.ReadLine()) != null)
                {
                    string[] guildInfo = guildRecord.Split('\t');
                    string guildId = guildInfo[0];
                    string guildName = guildInfo[1];

                    //parse the guild ID to an unsigned integer
                    uint.TryParse(guildId, out uintGuildId);

                    //add the guilds to a dictionary so we can access them 
                    guilds.Add(uintGuildId, guildName);
                }
            }

            foreach (var keyValue in guilds)
            {
                if (keyValue.Value == guildNameToFind)
                {
                    return keyValue.Key;
                }
            }
            return 0;
        }
        public void EmptyGear(int index)
        {
            //following switch structure evaluates if the index value is 0, if so it
            //will print that that item type is empty
            switch (index)
            {
                case 0:
                    Console.WriteLine("Helmet: empty");
                    break;
                case 1:
                    Console.WriteLine("Neck: empty");
                    break;
                case 2:
                    Console.WriteLine("Shoulder: empty");
                    break;
                case 3:
                    Console.WriteLine("Back: empty");
                    break;
                case 4:
                    Console.WriteLine("Chest: empty");
                    break;
                case 5:
                    Console.WriteLine("Wrist: empty");
                    break;
                case 6:
                    Console.WriteLine("Gloves: empty");
                    break;
                case 7:
                    Console.WriteLine("Belt: empty");
                    break;
                case 8:
                    Console.WriteLine("Pants: empty");
                    break;
                case 9:
                    Console.WriteLine("Boots: empty");
                    break;
                case 10:
                case 11:
                    Console.WriteLine("Ring: empty");
                    break;
                case 12:
                case 13:
                    Console.WriteLine("Trinket: empty");
                    break;
                default:
                    Console.WriteLine("Index out of range");
                    break;
            }
        }
        public override string ToString()
        {
            //checking if the player is part of a guild (guildID > 0)
            if(this.guildId > 0)
            {
                //find the guild name based on the ID
                string name = FindGuildName(this.guildId);
                //return the printed string
                return ("Name: " + this.name + "\tRace: " + this.Race + "\tLevel: " + this.Level + "\tGuild: " + name);
            }
            //else they are not part of a guild, so do not print the guild name
            else
            {
                return ("Name: " + this.name + "\tRace: " + this.Race + "\tLevel: " + this.Level);

            }
        }
    }
}