using System;
using System.Collections.Generic;

namespace DnDTracker
{
    class Program
    {
        public static List<string> EmptyList = new List<string> { "None" };

        static void Main(string[] args)
        {
            //Monster.Initialize();
            //Character.Initialize();
            //Party.Initialize();
            //Player.Initialize();
            //Misc.Initialize();
            MainMenu();
        }

        public static void MainMenu()
        {
            Console.Clear();
            Misc.TopHeader();
            Console.WriteLine("1. Data Entry");
            Console.WriteLine("2. Combat Tracker");
            Console.WriteLine("3. View Stats");
            Console.WriteLine("4. Debug");
            Console.WriteLine("------------------");
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
                else if (temp == ConsoleKey.D4)
                {
                    DebugPage();
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
            else if (v == "Data Entry")
            {
                Console.WriteLine("Please enter your choice:");
                ConsoleKey temp = Console.ReadKey().Key;
                if (temp == ConsoleKey.D1)
                {
                    Character.CreateCharacter();
                }
                else if (temp == ConsoleKey.D2)
                {
                    Monster.CreateMonster();
                }
                else if (temp == ConsoleKey.D3)
                {
                    Player.CreatePlayer();
                }
                else if (temp == ConsoleKey.D4)
                {
                    Party.CreateParty();
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
                            GetUserInput("Data Entry");
                        }
                    }

                }
            }

        }

        private static void DebugPage()
        {
            throw new NotImplementedException();
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
            Console.Clear();
            Misc.TopHeader();
            Console.WriteLine("1. Create Character");
            Console.WriteLine("2. Create Monster");
            Console.WriteLine("3. Create Player");
            Console.WriteLine("4. Create Party");
            Console.WriteLine("------------------");
            GetUserInput("Data Entry");
        }


    }
}
