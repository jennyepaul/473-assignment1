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
            using (StreamReader inFile = new StreamReader("../../../players.txt"))
            {
                while ((playerRecord = inFile.ReadLine()) != null)
                {
                    Console.WriteLine(playerRecord);
                    //CODE YOUR PLAYER OBJECT STUFF HERE!
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
                        Console.WriteLine("You chose to print all the players out!");
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
    }
}
