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
            if(Resistances.Count == 0)
            {
                Resistances.Add("None");
            }
            if(Immunities.Count == 0)
            {
                Immunities.Add("None");
            }
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
                Misc.ListAllList(Misc.MonsterTypes);
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

        public static void EditMonster()
        {
            string temp;
            int tempInt = 1;
            bool tempBool = false;
            string name = "Unchanged";
            Monster tempMonster = new Monster();
            Misc.TopHeader();
            Console.WriteLine("Please choose a monster to edit: ");
            Misc.DisplayMonsters();
            //Select monster you wish to edit below
            while (!tempBool)
            {
                name = Console.ReadLine();
                if (Monster.Dictionary.ContainsKey(name))
                {
                    Console.WriteLine("Here:");
                    tempMonster = Monster.Dictionary[name];
                    tempBool = true;
                }
                else
                {
                    Console.WriteLine("You have entered an incorrect input, please try again. ");
                }
                if(Misc.MonsterTypes.Count == 0)
                {
                    Console.WriteLine("There are no monsters to edit. Returning to main menu, press any button to continue...");
                    Console.ReadKey();
                    Program.MainMenu();
                }
            }
            //Display all selected monster stats below
            bool tempBool3 = true;
            while (tempBool3)
            {
                Misc.TopHeader();
                Console.WriteLine($"Monster selected: {name} \nType: {tempMonster.Type}\nMax HP: {tempMonster.MaxHP}\nCR: {tempMonster.CR}");
                Console.WriteLine("Resistances:");
                Misc.ListAllList(tempMonster.Resistances);
                Console.WriteLine("Immunities:");
                Misc.ListAllList(tempMonster.Immunities);
                Console.WriteLine("------------------");
                Console.WriteLine("Please select what you would like to edit:");
                Console.WriteLine("1. Name\n2. Type\n3. Max HP \n4. CR\n5. Resistances \n6. Immunities\n7. Finish Editing\n8. Main Menu");
                try
                {
                    tempInt = Convert.ToInt32(Console.ReadLine());
                    tempBool = false;
                }
                catch
                {
                    Console.WriteLine("You have entered an incorrect input, please try again: ");
                    tempBool = true;
                }
                if (tempInt > 7 || tempInt < 0)
                {
                    Console.WriteLine("You have entered an incorrect input, please try again: ");
                    tempBool = true;
                }
                tempBool = true;
                switch (tempInt)
                {
                    case 1:
                        Misc.TopHeader();
                        Console.WriteLine("Please enter a new name: ");
                        tempMonster.Name = Console.ReadLine();
                        break;
                    case 2:
                        Misc.TopHeader();
                        while (tempBool)
                        {
                            tempBool = false;
                            Misc.TopHeader();
                            Console.WriteLine("Please enter a the type of the monster: ");
                            Misc.ListAllList(Misc.MonsterTypes);
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
                            if (tempInt > 12 || tempInt < 1)
                            {
                                tempBool = true;
                            }
                        }
                        tempInt = tempInt - 1;
                        tempMonster.Type = Misc.MonsterTypes[tempInt];
                        break;
                    case 3:
                        Misc.TopHeader();
                        Console.WriteLine("Please enter a new Max HP: ");
                        while (tempBool)
                        {
                            try
                            {
                                tempBool = true;
                                tempMonster.MaxHP = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("You have entered an invalid number, please try again: ");
                                tempBool = false;
                            }
                        }
                        break;
                    case 4:
                        Misc.TopHeader();
                        Console.WriteLine("Please enter the monster's CR: ");
                        while (tempBool)
                        {
                            try
                            {
                                tempBool = false;
                                tempMonster.CR = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("You have entered an invalid number, please try again: ");
                                tempBool = true;
                            }
                        }
                        break;
                    case 5:
                        bool tempBool2;
                        Misc.TopHeader();
                        Console.WriteLine("Resistances?: \nY: Yes \nN: No");
                        string tempRes;
                        while (tempBool)
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
                                        tempMonster.Resistances.Add(tempRes);
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
                        break;
                    case 6:
                        Misc.TopHeader();
                        Console.WriteLine("Immunity?: \nY: Yes \nN: No");
                        string tempImmune;
                        while (tempBool)
                        {
                            ConsoleKey tempKey = Console.ReadKey().Key;
                            if (tempKey == ConsoleKey.Y)
                            {
                                Console.WriteLine("Please enter the immunity you wish to add: ");
                                Misc.ListAllList(Misc.DamageTypes);
                                tempBool2 = true;
                                while (tempBool2)
                                {
                                    tempImmune = Console.ReadLine();
                                    if (Misc.DamageTypes.Contains(tempImmune))
                                    {
                                        tempMonster.Immunities.Add(tempImmune);
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
                        break;
                    case 7:
                        tempBool3 = false;
                        break;
                    default:
                        Console.WriteLine("You have entered an incorrect input. Returning to Main Menu...");
                        Console.ReadKey();
                        Program.MainMenu();
                        break;
                }
                //END OF SWITCH
            }
            Misc.TopHeader();
            Console.WriteLine("The following is the edited monster stats: ");
            Console.WriteLine($"Monster selected: {tempMonster.Name} \nType: {tempMonster.Type}\nMax HP: {tempMonster.MaxHP}\nCR: {tempMonster.CR}");
            Console.WriteLine("Is this information correct?:\n1. Yes\n2. No ");
            ConsoleKey enterKey = Console.ReadKey().Key;
            if (enterKey != ConsoleKey.D1)
            {
                Program.MainMenu();
            }
            else
            {
                Monster.Dictionary.Remove(name);
                Monster.Dictionary.Add(tempMonster.Name, tempMonster);
                Console.WriteLine($"Monster {tempMonster.Name} successfully edited...");
                Console.ReadKey();
                Program.MainMenu();
            }

        }
    }


}
