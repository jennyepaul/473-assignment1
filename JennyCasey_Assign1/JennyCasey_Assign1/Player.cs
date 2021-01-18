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
        public readonly uint id;
        public readonly string name;
        public readonly string race;
        public uint level;
        public uint exp; 
        public uint guildID;
        public List<uint> inventory;

        string[] gear =
        {
            "Newbie's Helmet", "Newbie's Cloak", "Newbie's Raiment",
            "Newbie's Gloves", "Newbie's Trousers", "Newbie's Sandals",
            "Slacker", "Nebula's Pauldrons", "Dread Pirate Nebula's Cloak",
            "Nebula's Resentment", "Nebula's Wristgaurds", "Nebula's Fury",
            "The Spire", "Nebula's Legguards", "Nebula's Stompers", "Gamora's Acceptance",
            "Gamora's Love", "Infinity Gauntlet"
        };

        // default constructor 
        public Player()
        {
            id = 0;
            name = " ";
            race = "";
            level = 0;
            exp = 0;
            guildID = 0;
            gear = 0;
            inventory = 0;
        }


        //alternate constructor
        public Player(uint id, string name, string race, uint level, uint exp, uint guildID, uint gear, List<uint> inventory)
        {
            this.id = id;
            this.name = name;
            this.race = race;
            this.level = level;
            this.exp = exp;
            this.guildID = guildID;
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
        public string name
        {
            get
            {
                return name;
            }
        }

        //only a getter, since only readonly
        public string race
        {
            get
            {
                return race;
            }
        }

        public uint level
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

        public uint exp
        {
            //free read/write acess so getter and setters
            get
            {
                return exp;
            }
            set
            {
                //only incremnt exp if it does not exceed MAX_LEVEL
                exp = exp + value;
            }
        }

        public uint guildID
        {
            //free read/write acess so getter and setters
            get
            {
                return guildID;
            }
            set
            {
                guildID = value;
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

        public List<uint> inventory
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

    }