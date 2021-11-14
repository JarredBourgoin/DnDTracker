using System.Collections.Generic;

namespace DnDTracker
{
    class Monster
    {
        public string Type { get; private set; }
        public string Name { get; private set; }
        public int MaxHP { get; private set; }
        public int CR { get; private set; }
        public List<string> Resistances { get; private set; }
        public List<string> Immunities { get; private set; }
        //CONSTRUCTOR:
        public Monster(string type, string name, int maxhp, int cr)
        {
            Type = type;
            Name = name;
            MaxHP = maxhp;
            CR = cr;
        }
        public Monster(string type, string name, int maxhp, int cr, List<string> res = null, List<string> immune = null)
        {
            Type = type;
            Name = name;
            MaxHP = maxhp;
            CR = cr;
            Resistances = res;
            Immunities = immune;
        }

        public static void InitializeMonsters()
        {
            Dictionaries.Monsters.Add("Kobold", CreateMonster("Humanoid", "Kobold", 5, 1));
            Dictionaries.Monsters.Add("Dragon", CreateMonster("Dragon", "Ancient White Dragon", 350, 21, new List<string>{ "Cold" }));
        }

        public static Monster CreateMonster(string type, string name, int maxhp, int cr)
        {
            Monster temp = new Monster(type, name, maxhp, cr);
            return temp;
        }
        public static Monster CreateMonster(string type, string name, int maxhp, int cr, List<string> res = null, List<string> immune = null)
        {
            Monster temp = new Monster(type, name, maxhp, cr, res, immune);
            return temp;
        }
    }


}
