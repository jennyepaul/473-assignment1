/* CSCI473 
 * Assignment 1
 * DATE: 1/26/2020
 * TEAM: JennyCasey
 * Contributors: Jennifer Paul (z1878099) and Casey McDermott (z1878096)
 * PURPOSE: The purpose of this assignment is to emulate a game. The program will read in 
 *          input files of equipment.txt, players.txt, and guilds.txt. From there, there 
 *          will be 3 dictionaries made, one for the items in equipment.txt, one for the players,
 *          and one for the guilds. Then the user will be presented with a menu where they will make
 *          choices such as listing all the players, having a player join/leave a guild, see the
 *          equipment for a specific players,etc. 
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
            bool isContinuing = true;
            
            //creating objects of player and item class
            Player player1 = new Player();
            Item item1 = new Item();

            //build the 3 tables
            var guildTable = player1.BuildGuildTable();
            var items = item1.BuildItemDictionary();
            var players = player1.BuildPlayerTable();

            //print out the menu and the options to the user
            Console.WriteLine("Welcome to the World of ConflictCraft: Testing Environment!");
            
            //while loop checks for flag if we should continue, this will be set to false (do not continue, exit out of program) when
            //the user enters any of the 'quit' options
            while(isContinuing)
            {
                //beginning message and menu options
                Console.WriteLine("\nWelcome to World of ConflictCraft: Testing Environment. Please select an option from the list below:");
                Console.WriteLine(String.Format(formatMenuString, choiceOne, choiceTwo, choiceThree, choiceFour,
                                                                choiceFive, choiceSix, choiceSeven, choiceEight,
                                                                choiceNine, quit));
                //read the choice from the user
                choice = Console.ReadLine();

                //switch to perform various tasks based on what option the user enters
                switch (choice)
                {
                    case "1":
                        player1.SortPlayerNames(players);
                        break;
                    case "2":
                        foreach(var i in guildTable)
                        {
                            Console.WriteLine(i.Value);
                        }
                        break;
                    case "3":
                        item1.PrintAllItems(items);
                        break;
                    case "4":
                        player1.PrintGearListForPlayer(players, items);                       
                        break;
                    case "5":
                        player1.PlayerLeaveGuild(players);
                        break;
                    case "6":
                        player1.PlayerJoinGuild(players);
                        break;
                    case "7":
                        player1.PlayerEquipGear(players, items);
                        break;
                    case "8":
                        player1.PlayerUnequipGear(players);
                        break;
                    case "9":
                        player1.AwardExperience(players);
                        break;
                    case "10": case "q": case "Q": case "quit": case "Quit": case "exit": case "Exit":
                        Console.WriteLine("Exiting program...");
                        isContinuing = false;
                        break;
                    case "11": case "T":
                        item1.SortItemNames(items);
                        Console.WriteLine("------------------------------------------");
                        player1.SortPlayerNames(players);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
