using System;
using System.Collections.Generic;

namespace DnDTracker
{
    class Character
    {
        //STATIC
        public static Dictionary<string, Character> Dictionary = new Dictionary<string, Character>();
        //
        public string PlayerName { get; private set; }
        public string Name { get; private set; }
        public int MaxHP { get; private set; }
        public int CurrentHP { get; set; }
        public Classes PlayerClasses { get; set; }
        public string MonsterType { get; set; }
        public bool IsMonster { get; private set; }
        public int Level { get; set; }
        public string Race { get; private set; }
        public List<String> Resistances { get; set; }
        public List<String> Immunities { get; set; }
        ///Constructors
        public Character(string name, int maxHP, int currentHP, Classes playerClass, string owner = "None")
        {
            PlayerName = owner;
            Name = name;
            MaxHP = maxHP;
            CurrentHP = currentHP;
            PlayerClasses = playerClass;
            IsMonster = false;
        }
        public Character(string name, int maxHP, int currentHP, Classes playerClass, List<string> res, List<string> immune, bool isMonster, int Level, string owner = "None")
        {
            
            Name = name;
            MaxHP = maxHP;
            CurrentHP = currentHP;
            PlayerClasses = playerClass;
            IsMonster = isMonster;
            Resistances = res;
            Immunities = immune;
        }

        public Character(Monster m, int currentHP = -1)
        {
            Name = m.Name;
            MaxHP = m.MaxHP;
            if (currentHP == -1) { CurrentHP = m.MaxHP; } else { CurrentHP = currentHP; }
            MonsterType = m.Type;
            IsMonster = true;
            Resistances = m.Resistances;
            Immunities = m.Immunities;
        }
        //
        public static void Initialize()
        {

        }

        public static void CreateCharacter()
        {
            Console.Clear();
            Misc.TopHeader();
            bool tempBool = false;
            bool tempBool2 = false;
            bool validClass = false;
            bool temp = false;
            string PlayerName = "None";
            string Name;
            int MaxHP = 1;
            int CurrentHP = 1;
            int Level = 0;
            int levelsRemaining = 0;
            Classes PlayerClass = new Classes();
            string tempClass;
            int tempClassLevel = 1;
            bool IsMonster = false;
            List<String> Resistances = new List<string>();
            string tempRes;
            string tempImmune;
            List<String> Immunities = new List<string>();
            Console.WriteLine("Welcome to the Character Creator. ");
            Console.WriteLine("Would you like to create a character?: (Y/N) ");
            ConsoleKey enterKey = Console.ReadKey().Key;
            if (enterKey != ConsoleKey.Y)
            {
                Program.MainMenu();
            }
            Console.WriteLine("Please enter a character name: ");
            Name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Please enter an owning player: ");
            Misc.DisplayPlayers();
            while (!temp)
            {
                PlayerName = Console.ReadLine();
                if (Player.Dictionary.ContainsKey(PlayerName))
                {
                    temp = true;
                }
                else
                {
                    Console.WriteLine("That player does not exist! Please try again: ");
                }
            }
            Console.WriteLine("Please enter the max HP: ");
            temp = false;
            while (!temp)
            {
                try
                {
                    temp = true;
                    MaxHP = Convert.ToInt32(Console.ReadLine());
                    CurrentHP = MaxHP;
                    //Debug:
                    Console.WriteLine(CurrentHP);
                }
                catch
                {
                    Console.WriteLine("You have entered an invalid number, please try again: ");
                }
            }
            temp = false;
            Console.WriteLine("Please enter your character's level: ");
            while (!temp)
            {
                try
                {
                    temp = true;
                    Level = Convert.ToInt32(Console.ReadLine());
                    levelsRemaining = Level;
                }
                catch
                {
                    Console.WriteLine("You have entered an invalid number, please try again: ");
                }
            }
            Misc.ListAllList(Misc.Classes);
            while(levelsRemaining > 0)
            {
                    Console.WriteLine("What class would you like to put levels into?: ");
                    tempClass = Console.ReadLine();
                    if (Misc.Classes.Contains(tempClass))
                    {
                        Console.WriteLine("How many levels would you like to put into this class?: ");
                        try
                        {
                            tempClassLevel = Convert.ToInt32(Console.ReadLine());
                            validClass = true;
                            if(tempClassLevel > levelsRemaining)
                            {
                                validClass = false;
                                Console.WriteLine("You don't have that many levels to spend!");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("That is an invalid entry. Please try again.");
                        }
                        if (validClass && PlayerClass.Class1 != null)
                        {
                            PlayerClass.Class1 = tempClass;
                            PlayerClass.Class1Level = tempClassLevel;
                            levelsRemaining -= tempClassLevel;
                        }
                        if (validClass && PlayerClass.Class2 != null)
                        {
                        PlayerClass.Class2 = tempClass;
                        PlayerClass.Class2Level = tempClassLevel;
                        levelsRemaining -= tempClassLevel;
                        }
                        if (validClass && PlayerClass.Class3 != null)
                        {
                        PlayerClass.Class3 = tempClass;
                        PlayerClass.Class3Level = tempClassLevel;
                        levelsRemaining -= tempClassLevel;
                        }
                }
            }
            Console.WriteLine("Resistances?: \n1: Yes \n2: No");
            while (!tempBool)
            {
                ConsoleKey tempKey = Console.ReadKey().Key;
                if (tempKey == ConsoleKey.D1)
                {
                    Console.WriteLine("Please enter the resistance you wish to add: ");
                    Misc.ListAllList(Misc.DamageTypes);
                    tempBool2 = true;
                    while (tempBool2)
                    {
                        tempRes = Console.ReadLine();
                        if (Misc.DamageTypes.Contains(tempRes))
                        {
                            Resistances.Add(tempRes);
                            tempBool2 = false;
                        }
                        else
                        {
                            Console.WriteLine("That is not a damage type. Please try again.");
                        }
                    }
                }
                else if (tempKey == ConsoleKey.D2)
                {
                    tempBool = true;
                }
            }
            tempBool2 = false;
            tempBool = true;
            while (tempBool)
            {
                ConsoleKey tempKey = Console.ReadKey().Key;
                if (tempKey == ConsoleKey.D1)
                {
                    Console.WriteLine("Please enter the resistance you wish to add: ");
                    Misc.ListAllList(Misc.DamageTypes);
                    tempBool2 = true;
                    while (tempBool2)
                    {
                        tempImmune = Console.ReadLine();
                        if (Misc.DamageTypes.Contains(tempImmune))
                        {
                            Resistances.Add(tempImmune);
                            tempBool2 = false;
                        }
                        else
                        {
                            Console.WriteLine("That is not a damage type. Please try again.");
                        }
                    }
                }
                else if (tempKey == ConsoleKey.D2)
                {
                    tempBool = false;
                }
            }
            Character.Dictionary.Add(Name, new Character(Name, MaxHP, CurrentHP, PlayerClass, Resistances, Immunities, IsMonster, Level, owner:PlayerName));
            Program.MainMenu();
        }



    }
}
