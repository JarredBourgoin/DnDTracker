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
            foreach(string i in List)
            {
                Console.WriteLine(i);
            }
        }
        public static void ListAllList(List<int> List)
        {
            foreach (int i in List)
            {
                Console.WriteLine(Convert.ToString(i));
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
    }
}
