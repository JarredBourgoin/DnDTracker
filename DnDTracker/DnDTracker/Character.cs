using System;
using System.Collections.Generic;

namespace DnDTracker
{
    class Character
    {
        public static Dictionary<string,Character> AllCharacters;
        public string Name { get; private set; }
        public int MaxHP { get; private set; }
        public int CurrentHP { get; set; }
        public string PlayerClass { get; set; }
        public bool IsMonster { get; private set; }
        public List<String> Resistances { get; set; }
        public List<String> Immunities { get; set; }
        ///Constructors
        public Character(string name, int maxHP, int currentHP, string playerClass)
        {
            Name = name;
            MaxHP = maxHP;
            CurrentHP = currentHP;
            PlayerClass = playerClass;
            IsMonster = false;
        }
        public Character(string name, int maxHP, int currentHP, string playerClass, List<string> res, List<string> immune, bool isMonster)
        {
            Name = name;
            MaxHP = maxHP;
            CurrentHP = currentHP;
            PlayerClass = playerClass;
            IsMonster = isMonster;
            Resistances = res;
            Immunities = immune;
        }

        public Character(Monster m, int currentHP = -1)
        {
            Name = m.Name;
            MaxHP = m.MaxHP;
            if (currentHP == -1) { CurrentHP = m.MaxHP; } else { CurrentHP = currentHP; }
            PlayerClass = m.Type;
            IsMonster = true;
            Resistances = m.Resistances;
            Immunities = m.Immunities;
        }
        ///
    }
}
