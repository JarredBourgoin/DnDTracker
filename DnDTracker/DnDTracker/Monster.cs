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
            bool tempBool2 = false;
            string type = "type";
            int maxHp = 1;
            int cr = 1;
            List<string> resistances = new List<string>();
            List<string> immunities = new List<string>();
            bool tempBool = true;
            int i = 1;
            int tempInt = -1;
            string temp;
            string name = "name";
            Console.Clear();
            Misc.TopHeader();
            Console.WriteLine("Welcome to the Monster Creator. ");
            Console.WriteLine("Would you like to create a Monster?: (Y/N) ");
            ConsoleKey enterKey = Console.ReadKey().Key;
            if (enterKey != ConsoleKey.Y)
            {
                Program.MainMenu();
            }
            Misc.TopHeader();
            Console.WriteLine("Please enter a name: ");
            name = Console.ReadLine();
            while (tempBool)
            {
                tempBool = false;
                Misc.TopHeader();
                Console.WriteLine("Please enter a the type of the monster: ");
                foreach (string m in Misc.MonsterTypes)
                {
                    Console.WriteLine($"{i}. {m}");
                    i++;
                }
                temp = Console.ReadLine();
                try
                {
                    tempInt = Convert.ToInt32(temp);
                }
                catch
                {
                    Console.WriteLine("You have entered an incorrect value. Please try again...");
                    Console.ReadKey();
                    tempBool = true;
                }
                if(tempInt > 12 || tempInt < 1)
                {
                    tempBool = true;
                }
            }
            tempInt = tempInt - 1;
            type = Misc.MonsterTypes[tempInt];
            Misc.TopHeader();
            Console.WriteLine("Please enter the monster's max hp: ");
            while (!tempBool)
            {
                try
                {
                    tempBool = true;
                    maxHp = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("You have entered an invalid number, please try again: ");
                    tempBool = false;
                }
            }
            Misc.TopHeader();
            Console.WriteLine("Please enter the monster's CR: ");
            while (tempBool)
            {
                try
                {
                    tempBool = false;
                    cr = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("You have entered an invalid number, please try again: ");
                    tempBool = true;
                }
            }
            Misc.TopHeader();
            Console.WriteLine("Resistances?: \nY: Yes \nN: No");
            string tempRes;
            while (!tempBool)
            {
                ConsoleKey tempKey = Console.ReadKey().Key;
                if (tempKey == ConsoleKey.Y)
                {
                    Console.WriteLine("Please enter the resistance you wish to add: ");
                    Misc.ListAllList(Misc.DamageTypes);
                    tempBool2 = true;
                    while (tempBool2)
                    {
                        tempRes = Console.ReadLine();
                        if (Misc.DamageTypes.Contains(tempRes))
                        {
                            resistances.Add(tempRes);
                            tempBool2 = false;
                        }
                        else
                        {
                            Console.WriteLine("That is not a damage type. Please try again.");
                        }
                    }
                }
                else if (tempKey == ConsoleKey.N)
                {
                    tempBool = true;
                }
            }
            string tempImmune;
            Misc.TopHeader();
            Console.WriteLine("Immunities?: \nY: Yes \nN: No");
            tempBool = false;
            while (!tempBool)
            {
                ConsoleKey tempKey = Console.ReadKey().Key;
                if (tempKey == ConsoleKey.Y)
                {
                    Console.WriteLine("Please enter the immunities you wish to add: ");
                    Misc.ListAllList(Misc.DamageTypes);
                    tempBool2 = true;
                    while (tempBool2)
                    {
                        tempImmune = Console.ReadLine();
                        if (Misc.DamageTypes.Contains(tempImmune))
                        {
                            immunities.Add(tempImmune);
                            tempBool2 = false;
                        }
                        else
                        {
                            Console.WriteLine("That is not a damage type. Please try again.");
                        }
                    }
                }
                else if (tempKey == ConsoleKey.N)
                {
                    tempBool = true;
                }
            }
            Monster.Dictionary.Add(name, new Monster(type, name, maxHp, cr, resistances, immunities));
            Console.WriteLine($"Monster {name} Created! Press any key to continue...");
            Console.ReadKey();
            Program.MainMenu();
        }

        internal static void EditMonster()
        {
            throw new NotImplementedException();
        }
    }


}
