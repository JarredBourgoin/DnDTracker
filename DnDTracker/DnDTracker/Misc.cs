using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DnDTracker
{
    class Misc
    {
        public static List<string> Classes = new List<string> {"Wizard", "Cleric", "Warlock", "Druid", "Artificer", "Paladin", "Barbarian", "Fighter", "Rogue", "Sorcerer", "Bard", "Monk", "Ranger"};
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
        public static void DisplayPlayers()
        {
            foreach (var p in Player.Dictionary.Values)
            {
                Console.WriteLine(p.Name);
            }
        }
        public static void TopHeader()
        {
            Console.WriteLine("Bourgoin's Tracker");
            Console.WriteLine("------------------");
        }
    }
}
