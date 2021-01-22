/* CSCI473 
 * Assignment 1
 * TEAM: JennyCasey
 * Contributors: Jennifer Paul (z1878099) and Casey McDermott (ID HERE)
 */
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace JennyCasey_Assign1
{
    public enum ItemType
    {
        Helmet, Neck, Shoulders, Back, Chest,
        Wrist, Gloves, Belt, Pants, Boots,
        Ring, Trinket
    };

    public enum Race { Orc, Troll, Tauren, Forsaken };

    class Program
    {
        private const string formatMenuString = "\t{0}\n\t{1}\n\t{2}\n\t{3}\n\t{4}\n\t{5}\n\t{6}\n\t{7}\n\t{8}\n\t{9}";
        private const string choiceOne = "1.) Print All Players";
        private const string choiceTwo = "2.) Print All Guilds";
        private const string choiceThree = "3.) List All Gear";
        private const string choiceFour = "4.) Print Gear List for Player";
        private const string choiceFive = "5.) Leave Guild";
        private const string choiceSix = "6.) Join Guild";
        private const string choiceSeven = "7.) Equip Gear";
        private const string choiceEight = "8.) Unequip Gear";
        private const string choiceNine = "9.) Award Experience";
        private const string quit = "10.) Quit";
        static void Main(string[] args)
        {
            string choice;
            string itemRecord;
            string playerRecord;
            bool isContinuing = true;

            //new dictionary to hold item types
            var items = new Dictionary<uint, Item>();

            //trying to generalize and build only one dictionary of guilds, need to do this and clean up player.cs
            //dictionary to hold guilds
            //var guilds = new Dictionary<uint, string>();


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
                    
                    //each index corresponds to an attribute, so assign value 
                    string id = parameter[0];
                    string name = parameter[1];
                    string type = parameter[2];
                    string itemLvl = parameter[3];
                    string primary = parameter[4];
                    string stamina = parameter[5];
                    string req = parameter[6];
                    string flavor = parameter[7];
                    
                    //TryParse-ing each string to the proper data type to catch any possible exceptions
                    uint.TryParse(parameter[0], out parsedID);
                    Enum.TryParse(type, out parsedType);
                    uint.TryParse(parameter[3], out parsedILVL);
                    uint.TryParse(parameter[4], out parsedPRIM);
                    uint.TryParse(parameter[5], out parsedSTAMINA);
                    uint.TryParse(parameter[6], out parsedREQUIREMENT);
             
                    //constructing new object of the class
                    Item newItem = new Item(parsedID, name, parsedType, parsedILVL, parsedPRIM, parsedSTAMINA, parsedREQUIREMENT, flavor);
                   
                    //add the new item to the dictionary
                    items.Add(parsedID, newItem);
                }
            }

            //read through the player file and create a new object for each record
            //and store that into a dictionary
            var players = new Dictionary<uint, Player>();

            using (StreamReader inFile = new StreamReader("../../../players.txt"))
            {
                while ((playerRecord = inFile.ReadLine()) != null)
                {
                    uint parsed_id;
                    Race parsed_race;
                    uint parsed_level;
                    uint parsed_exp;
                    uint parsed_guildID;
                    

                    string[] parameter = playerRecord.Split('\t');

                    string id = parameter[0];
                    string name = parameter[1];
                    string race = parameter[2];
                    string level = parameter[3];
                    string exp = parameter[4];
                    string guildId = parameter[5];

                    string[] gear;
                    var list = new List<string>();
                    list.Add(parameter[6]);   //gear number 1
                    list.Add(parameter[7]);   //gear number 2
                    list.Add(parameter[8]);   //gear number 3
                    list.Add(parameter[9]);   //gear number 4
                    list.Add(parameter[10]);  //gear number 5
                    list.Add(parameter[11]);  //gear number 6
                    list.Add(parameter[12]);  //gear number 7
                    list.Add(parameter[13]);  //gear number 8
                    list.Add(parameter[14]);  //gear number 9
                    list.Add(parameter[15]);  //gear number 10
                    list.Add(parameter[16]);  //gear number 11
                    list.Add(parameter[17]);  //gear number 12
                    list.Add(parameter[18]);  //gear number 13
                    list.Add(parameter[19]);  //gear number 14
                    gear = list.ToArray();

                    uint.TryParse(parameter[0], out parsed_id);
                    Enum.TryParse(parameter[2], out parsed_race);
                    uint.TryParse(parameter[3], out parsed_level);
                    uint.TryParse(parameter[4], out parsed_exp);
                    uint.TryParse(parameter[5], out parsed_guildID);
                    uint[] parsedgear = Array.ConvertAll(gear, g => uint.TryParse(g, out var x) ? x : 0);
                    List<uint> inventory1 = null;                    

                    Player newPlayer = new Player(parsed_id, name, parsed_race, parsed_level, parsed_exp, parsed_guildID, parsedgear, inventory1);

                    players.Add(parsed_id, newPlayer);
                }
            }

            //print out the menu and the options to the user
            Console.WriteLine("Welcome to the World of ConflictCraft: Testing Environment!");
            
            //while loop checks for flag if we should continue, this will be set to false (do not continue, exit out of program) when
            //the user enters any of the 'quit' options
            while(isContinuing)
            {
                //beginning message and menu options
                Console.WriteLine("Welcome to World of ConflictCraft: Testing Environment. Please select an option from the list below:");
                Console.WriteLine(String.Format(formatMenuString, choiceOne, choiceTwo, choiceThree, choiceFour,
                                                                choiceFive, choiceSix, choiceSeven, choiceEight,
                                                                choiceNine, quit));
                //read the choice from the user
                choice = Console.ReadLine();

                //switch to perform various tasks based on what option the user enters
                switch (choice)
                {
                    case "1":
                        foreach (var player in players)
                        {
                            Console.WriteLine("{0}", player.Value);
                        }
                        break;
                    case "2":
                        printGuilds();
                        break;
                    case "3":
                        //iterate through dictionary and print the key (ID of item) and the value (attributes of item object)
                        foreach(var item in items)
                            Console.WriteLine("{0}" , item.Value);
                        break;
                    case "4":
                        Console.Write("Enter the player name: ");
                        string playerName1 = Console.ReadLine();
                        //search for the player in the players dictionary
                        //if we find it, then print out the player info
                        foreach(var name in players)
                        {
                            if (name.Value.Name == playerName1)
                            {
                               
                                //printing out the full value/info of player
                                Console.WriteLine("{0}", name.Value);

                                //iterated through item dictionary and if the ID of the gear
                                //matches the ID of the gear the player has, we print the info on it
                                foreach(var itemID in items)
                                {
                                    //search only the length of the player's gear[] to avoid errors
                                    for (int i = 0; i < name.Value.Length; i++)
                                    {

                                        if (itemID.Key == name.Value[i])
                                        {
                                            Console.WriteLine(itemID.Value);
                                        }
                                    }      
                                }
                            }
                        }
                        break;
                    case "5":
                        Console.Write("Enter the player name: ");
                        string playerName2 = Console.ReadLine();
                        bool playerFound = false;
                        
                        //search through the players dictionary for the username entered
                        foreach(var player in players)
                        {
                            //once we find it, set the flag, then set the guild to 0 since we want to leave
                            if(player.Value.Name == playerName2)
                            {
                                playerFound = true;
                                players[player.Key].GuildID = 0;
                            }
                        }
                        if(playerFound == false)
                        {
                            Console.WriteLine("Player not found");
                        }
                        break;
                    case "6":
                        Console.Write("Enter the player name: ");
                        string playerName3 = Console.ReadLine();
                        Console.Write("Enter the guild they will join: ");
                        string guildToJoin = Console.ReadLine();

                        //search for the name that the user entered in the players dictionary
                        foreach (var player in players)
                        {
                            if (player.Value.Name == playerName3)
                            {
                                //if we found it then call the FindGuildId method to find out the ID of
                                //the guild name entered
                                uint newGuildId = players[player.Key].FindGuildId(guildToJoin);

                                //set the guild to the guild ID and print out that player joined
                                players[player.Key].GuildID = newGuildId;
                                Console.WriteLine("{0} has joined {1}!",playerName3, guildToJoin);
                            }
                        }
                        break;
                    case "7":
                        Console.WriteLine("You chose to equip some gear!");
                        break;
                    case "8":
                        Console.WriteLine("You chose to unequip some gear!");
                        break;
                    case "9":
                        //get the player name then do a lookup in the dictionary for that player
                        Console.Write("Enter the player name: ");
                        string playerName4 = Console.ReadLine();
                        
                        //get the experience to award then add that to the exp the player already has
                        Console.Write("Enter the amount of experience to award: ");
                        string experience = Console.ReadLine();
                        uint uintExperience;
                        uint.TryParse(experience, out uintExperience);

                        //goes through the players dictionart
                        foreach (var player in players)
                        {
                            //if the name the user entered is a value in the dictionary, then we want to add experience
                            //but only if the level is less than 60 (since that is MAX_LEVEL)
                            //MAY NEED TO FIND A WAY TO CLEAN THIS UP/MAKE A FUNCTION/ investigate why setter isn't doing this
                            if(player.Value.Name == playerName4)
                            {
                                    Console.WriteLine("Experience before adding exp: {0}", player.Value.Exp);
                                    players[player.Key].Exp = uintExperience;

                                    //if enough experience was entered, we may need to level up
                                    if((uintExperience > 1000) && (players[player.Key].Level < 60))
                                    {
                                        Console.WriteLine("Ding!");
                                        Console.WriteLine("Ding!");
                                        Console.WriteLine("Ding!");
                                        players[player.Key].LevelUp(uintExperience);
                                    }
                                Console.WriteLine("Experience after  adding exp: {0}", player.Value.Exp);
                            }
                        }
                        break;
                    case "10": case "q": case "Q": case "quit": case "Quit": case "exit": case "Exit":
                        Console.WriteLine("Exiting program...");
                        isContinuing = false;
                        break;
                    case "11": case "T":
                        //will make use of IComparable by creating new sortedSets for Item and Player
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        //just putting a method here to print the guilds, may need to adjust or move this somewhere else
        static void printGuilds()
        {
            string guildRecord;
            using (StreamReader inFile = new StreamReader("../../../guilds.txt"))
            {
                while ((guildRecord = inFile.ReadLine()) != null)
                {
                    string[] guildInfo = guildRecord.Split('\t');
                    string guildId = guildInfo[0];
                    string guildName = guildInfo[1];
                    Console.WriteLine("{0}", guildName);
                }
            }
        }
    }
}
