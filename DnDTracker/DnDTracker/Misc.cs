using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DnDTracker
{
    class Misc
    {
        public static List<string> Classes = new List<string> {"Wizard", "Cleric", "Warlock", "Druid", "Artificer", "Paladin", "Barbarian", "Fighter", "Rogue", "Sorcerer", "Bard", "Monk", "Ranger"};
        public static List<string> MonsterTypes = new List<string> { "Aberration", "Beast", "Celestial", "Construct", "Dragon", "Elemental", "Fey", "Fiend", "Giant", "Humanoid", "Monstrosity", "Ooze", "Plant", "Undead" };
        public static List<string> DamageTypes = new List<string> { "Slashing", "Piercing", "Bludgeoning", "Poison", "Acid", "Fire", "Cold", "Radiant", "Necrotic", "Lightning", "Thunder", "Force", "Psychic" };
        public static void Initialize()
        {
            throw new NotImplementedException();
        }

        public static void ListAllList(List<string> List)
        {
            int j = 1;
            if(List != null)
            {
                foreach (string i in List)
                {
                    Console.WriteLine($"{j}. {i}");
                    j++;
                }
            }
        }
        public static void ListAllList(List<int> List)
        {
            int j = 1;
            if(List != null)
            {
                foreach (int i in List)
                {
                    Console.WriteLine($"{j}. {i}");
                    j++;
                }
            }
        }
        public static void DisplayAllCharacters()
        {
            int i = 1;
            foreach (var p in Character.Dictionary.Values)
            {
                Console.WriteLine($"{i}. {p.Name}");
                i++;
            }
        }
        public static void DisplayPlayers()
        {
            int i = 1;
            foreach (var p in Player.Dictionary.Values)
            {
                Console.WriteLine($"{i}. {p.Name}");
                i++;
            }
        }
        public static void DisplayMonsters()
        {
            int i = 1;
            foreach (var p in Monster.Dictionary.Values)
            {
                Console.WriteLine($"{i}. {p.Name}");
                i++;
            }
        }
        public static void DisplayParties()
        {
            int i = 1;
            foreach (var p in Party.Dictionary.Values)
            {
                Console.WriteLine($"{i}. {p.Name}");
                i++;
            }
        }
        public static void TopHeader()
        {
            Console.Clear();
            Console.WriteLine("Bourgoin's Tracker");
            Console.WriteLine("------------------");
        }

        public static void WriteLine()
        {
            Console.WriteLine("------------------");
        }

        public static bool Continue(string whatAreYouDoing)
        {
            bool whileLoopBool = true;
            Misc.TopHeader();
            Console.WriteLine($"Would you like to continue {whatAreYouDoing}?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            Misc.WriteLine();
            while (whileLoopBool)
            {
                ConsoleKey temp = Console.ReadKey().Key;
                switch (temp)
                {
                    case ConsoleKey.D1:
                        return true;
                    case ConsoleKey.D2:
                        return false;
                    default:
                        Console.WriteLine("You have entered an incorrect value, please try again.");
                        break;
                }
            }
            return false;
        }
    }
}
