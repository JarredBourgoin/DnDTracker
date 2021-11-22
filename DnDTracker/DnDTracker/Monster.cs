using System;
using System.Collections.Generic;

namespace DnDTracker
{
    class Monster
    {
        //STATIC
        public static Dictionary<string, Monster> Dictionary = new Dictionary<string, Monster>();
        //
        public string Type { get; private set; }
        public string Name { get; private set; }
        public int MaxHP { get; private set; }
        public int CR { get; private set; }
        public List<string> Resistances { get; private set; }
        public List<string> Immunities { get; private set; }
        //CONSTRUCTOR:
        public Monster()
        {
        }
        public Monster(string type, string name, int maxhp, int cr)
        {
            Type = type;
            Name = name;
            MaxHP = maxhp;
            CR = cr;
        }
        public Monster(string type, string name, int maxhp, int cr, List<string> res, List<string> immune)
        {
            Type = type;
            Name = name;
            MaxHP = maxhp;
            CR = cr;
            Resistances = res;
            Immunities = immune;
        }

        public static void Initialize()
        {
            Monster.Dictionary.Add("Kobold", new Monster("Humanoid", "Kobold", 5, 1));
            Monster.Dictionary.Add("Dragon", new Monster("Dragon", "Ancient White Dragon", 350, 21, new List<string>{ "Cold" }, Program.EmptyList));
        }

        public static void CreateMonster()
        {
            throw new NotImplementedException();
        }
    }


}
