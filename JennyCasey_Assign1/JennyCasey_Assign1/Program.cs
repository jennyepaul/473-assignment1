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
        static void Main(string[] args)
        {
            string choiceOne = "1.) Print All Players";
            string choiceTwo = "2.) Print All Guilds";
            string choiceThree = "3.) List All Gear";
            string choiceFour = "4.) Print Gear List for Player";
            string choiceFive = "5.) Leave Guild";
            string choiceSix = "6.) Join Guild";
            string choiceSeven = "7.) Equip Gear";
            string choiceEight = "8.) Unequip Gear";
            string choiceNine = "9.) Award Experience";
            string quit = "10.) Quit";
            string choice;
            bool isContinuing = true;

            //new dictionary to hold item types
            var items = new Dictionary<uint, Item>();

            //create a new Item/Player object for each record
            //store it into separate dictionary collections
            string itemRecord;
            string playerRecord;
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

                    string[] parameter = itemRecord.Split('\t');
                    
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
            var players = new Dictionary<uint, string>();

            using (StreamReader inFile = new StreamReader("../../../players.txt"))
            {
                while ((playerRecord = inFile.ReadLine()) != null)
                {
                    //Console.WriteLine(playerRecord);

                    /*uint parsed_id;
                    //string parsed_name;
                    Race parsed_race;
                    uint parsed_level;
                    uint parsed_exp;
                    uint parsed_guildID;
                    //uint[] parsed_gear;
                    //List<uint> parsed_inventory;*/

                    string[] parameter = playerRecord.Split('\t');

                    string id = parameter[0];
                    string name = parameter[1];
                    string race = parameter[2];
                    string level = parameter[3];
                    string exp = parameter[4];
                    string guildId = parameter[5];
                    //string gear = parameter[6];
                    //string inventory = parameter[7];

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

                    //Console.WriteLine("ID: {0} Name: {1} Gear(3): {2} Gear(14): {3}", id, name, gear[2], gear[13]);
                    Console.WriteLine("Gears in Order: (0) {0}, (1) {1}, (2) {2}, (3) {3}, (4) {4}, (5) {5},(6) {6}", 
                        gear[0], gear[1], gear[2], gear[3], gear[4], gear[5], gear[6]);
                    Console.WriteLine("Gear (7): {0}", gear[7]);
                    Console.WriteLine("Gear (8): {0}", gear[8]);
                    Console.WriteLine("Gear (9): {0}", gear[9]);
                    Console.WriteLine("Gear (10): {0}", gear[10]);
                    Console.WriteLine("Gear (11): {0}", gear[11]);
                    Console.WriteLine("Gear (12): {0}", gear[12]);
                    Console.WriteLine("Gear (13): {0}", gear[13]);

                    /*uint.TryParse(parameter[0], out parsed_id);
                    Enum.TryParse(parameter[2], out parsed_race);
                    uint.TryParse(parameter[3], out parsed_level);
                    uint.TryParse(parameter[4], out parsed_exp);
                    uint.TryParse(parameter[5], out parsed_guildID);
                    //uint[].TryParse(parameter[6], out parsed_gear);
                    //List<uint>.Tryparse(parameter[7], out parsed_inventory);

                    Player newPlayer = new Player(parsed_id, name, parsed_race, parsed_level, parsed_exp, parsed_guildID, gear, inventory);

                    players.Add(parsed_id, newPlayer);*/
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
                        //Console.WriteLine("Name: {0}", Players.name); //??? review later
                        break;
                    case "2":
                        printGuilds();
                        break;
                    case "3":
                        //iterate through dictionary and print the key (ID of item) and the value (attributes of item object)
                        foreach(var kvp in items)
                            Console.WriteLine("{0}" ,kvp.Value);
                        break;
                    case "4":
                        Console.WriteLine("You chose to print the gear list for the player ");
                        break;
                    case "5":
                        Console.WriteLine("You chose to leave the guild");
                        break;
                    case "6":
                        Console.WriteLine("You chose to join a guild!");
                        break;
                    case "7":
                        Console.WriteLine("You chose to equip some gear!");
                        break;
                    case "8":
                        Console.WriteLine("You chose to unequip some gear!");
                        break;
                    case "9":
                        Console.WriteLine("Let's award some experience now");
                        break;
                    case "10": case "q": case "Q": case "quit": case "Quit": case "exit": case "Exit":
                        Console.WriteLine("Exiting program...");
                        isContinuing = false;
                        break;
                    case "11": case "T":
                        //will make use of IComparable
                        Console.WriteLine("You chose secret option 11");
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

        /*static void printPlayers()
        {
            string PlayersRecord;
            using (StreamReader inFile = new StreamReader("../../../player.txt"))
            {
                while ((PlayersRecord = inFile.ReadLine()) != null)
                {
                    string players = PlayersRecord.Split('\t');

                }
            }
        }*/
    }
}
