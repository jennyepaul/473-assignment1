using System;
using System.Text;

namespace JennyCasey_Assign1
{

    class Program
    {
        public enum ItemType
        {
            Helmet, Neck, Shoulders, Back, Chest,
            Wrist, Gloves, Belt, Pants, Boots,
            Ring, Trinket
        };

        public enum Race { Orc, Troll, Tauren, Forsaken };

        private static uint MAX_ILVL = 360;
        private static uint MAX_PRIMARY = 200;
        private static uint MAX_STAMINA = 275;
        private static uint MAX_LEVEL = 60;
        private static uint GEAR_SLOTS = 14;
        private static uint MAX_INVENTORY_SIZE = 20;
        private static string formatMenuString = "\t{0}\n\t{1}\n\t{2}\n\t{3}\n\t{4}\n\t{5}\n\t{6}\n\t{7}\n\t{8}\n\t{9}";
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

            //print out the menu and the options to the user
            Console.WriteLine("Welcome to the World of ConflictCraft: Testing Environment!");
            Console.WriteLine("Welcome to World of ConflictCraft: Testing Environment. Please select an option from the list below:");
            Console.WriteLine(String.Format(formatMenuString,choiceOne,choiceTwo,choiceThree,choiceFour,choiceFive,choiceSix,choiceSeven, choiceEight,
                                                choiceNine,quit));
     
            //read the choice from the user
            choice = Console.ReadLine();

            //lets print this back just to double check its working
            Console.WriteLine("you chose: {0}", choice);

        }
    }
}
