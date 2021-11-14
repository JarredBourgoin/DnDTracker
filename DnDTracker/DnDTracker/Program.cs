using System;

namespace DnDTracker
{
    class Program
    {
        public static Monster temp = new Monster("t", "t", 2, 2);

        static void Main(string[] args)
        {
            Monster.InitializeMonsters();
            Console.WriteLine(Dictionaries.Monsters["Ancient White Dragon"].Resistances);
            Console.ReadLine();
            MainMenu();
        }

        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Bourgoin's Tracker");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Data Entry");
            Console.WriteLine("2. Combat Tracker");
            Console.WriteLine("3. View Stats");
            Console.WriteLine("--------------");
            GetUserInput("mainMenu");
        }

        private static void GetUserInput(string v)
        {

            if (v == "mainMenu")
            {
                Console.WriteLine("Please enter your choice:");
                ConsoleKey temp = Console.ReadKey().Key;
                if (temp == ConsoleKey.D1)
                {
                    DataEntry();
                }
                else if (temp == ConsoleKey.D2)
                {
                    CombatTracker();
                }
                else if (temp == ConsoleKey.D3)
                {
                    StatsPage();
                }
                else
                {
                    bool wrongKeyWasPressed = true;
                    while (wrongKeyWasPressed)
                    {
                        Console.WriteLine("\nThe key you pressed was not a valid option. Press Escape to return to the main menu, or enter to try again...");
                        temp = Console.ReadKey().Key;
                        if (temp == ConsoleKey.Escape)
                        {
                            MainMenu();
                        }
                        else if (temp == ConsoleKey.Enter)
                        {
                            GetUserInput("mainMenu");
                        }
                    }

                }
            }
        }

        private static void StatsPage()
        {
            throw new NotImplementedException();
        }

        private static void CombatTracker()
        {
            throw new NotImplementedException();
        }

        private static void DataEntry()
        {
            
        }
    }
}
