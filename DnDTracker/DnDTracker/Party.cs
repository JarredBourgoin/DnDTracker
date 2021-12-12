using System;
using System.Collections.Generic;

namespace DnDTracker
{
    class Party
    {
        //STATIC
        public static Dictionary<string, Party> Dictionary = new Dictionary<string, Party>();
        //
        public string Name { get; set; }
        public List<Character> PartyMembers { get; set; }
        public int NumberOfMembers { get; set; }
        public int NumberOfMembersAlive { get; set; }
        public bool IsPlayerParty { get; set; }
        public Party(string name, bool j, List<Character> members)
        {
            Name = name;
            IsPlayerParty = j;
            PartyMembers = members;
            NumberOfMembers = PartyMembers.Count;
            NumberOfMembersAlive = PartyMembers.Count;
            foreach (Character i in PartyMembers)
            {
                if (i.CurrentHP < 1) { NumberOfMembersAlive -= 1; }
            }
        }

        public static void AddCharacter(Character c, Party p)
        {
            p.PartyMembers.Add(c);
            p.NumberOfMembers += 1;
            p.NumberOfMembersAlive += 1;
            int temp = p.PartyMembers.IndexOf(c);
            if (p.PartyMembers[temp].CurrentHP < 1)
            {
                p.NumberOfMembersAlive -= 1;
            }
        }


        public static void Initialize()
        {
            throw new NotImplementedException();
        }

        public static void EditParty()
        {
            string tempString;
            ConsoleKey enterKey;
            Party tempParty;
            string inputString = "none";
            bool whileLoopBool = true;
            bool whileLoopBool2 = true;
            bool whileLoopBool3 = true;
            Misc.TopHeader();
            if(Party.Dictionary.Count == 0)
            {
                Console.WriteLine("There are no existing parties to edit, returning to main menu...");
                Console.ReadKey();
                Program.MainMenu();
            }
            Console.WriteLine("Please enter the name of the party you wish to edit: ");
            Misc.DisplayParties();
            Console.WriteLine("---------------");
            whileLoopBool = true;
            while (whileLoopBool)
            {
                inputString = Console.ReadLine();
                if (Party.Dictionary.ContainsKey(inputString))
                {
                    whileLoopBool2 = true;
                    while (whileLoopBool2)
                    {
                        int i = 1;
                        tempParty = Party.Dictionary[inputString];
                        Misc.TopHeader();
                        Console.WriteLine($"You have selected the {tempParty.Name} Party. \nCurrent Members:");
                        foreach (Character c in tempParty.PartyMembers)
                        {
                            Console.WriteLine($"{i}. {c.Name}");
                        }
                        Misc.WriteLine();
                        Console.WriteLine("1. Add a character\n2. Remove a character\n3. Finish editing\n4. Return to main menu ");
                        enterKey = Console.ReadKey().Key;
                        bool isContained;
                        switch (enterKey)
                        {
                            case ConsoleKey.D1:
                                whileLoopBool3 = true;
                                while (whileLoopBool3)
                                {
                                    Misc.TopHeader();
                                    Console.WriteLine("Please add characters to the party.\nAvailable Characters: ");
                                    Misc.DisplayAllCharacters();
                                    if (Character.Dictionary.Count == 0)
                                    {
                                        Console.WriteLine("There are no available characters to add...");
                                        Console.ReadKey();
                                        Program.MainMenu();
                                    }
                                    tempString = Console.ReadLine();
                                    if (Character.Dictionary.ContainsKey(tempString))
                                    {
                                        tempParty.PartyMembers.Add(Character.Dictionary[tempString]);
                                        isContained = true;
                                    }
                                    else
                                    {
                                        if (tempString == "Escape")
                                        {
                                            Program.MainMenu();
                                        }
                                        isContained = false;
                                        Console.WriteLine("That character does not exist! Please try again: ");
                                    }
                                    if (isContained)
                                    {
                                        Console.WriteLine("Would you like to add another character? (Y/N): ");
                                        ConsoleKey temp = Console.ReadKey().Key;
                                        if (temp == ConsoleKey.N)
                                        {
                                            whileLoopBool3 = false;
                                        }
                                        isContained = false;
                                    }
                                }
                                break;
                            case ConsoleKey.D2:
                                whileLoopBool3 = true;
                                isContained = false;
                                Character tempCharacter = new Character();
                                while (whileLoopBool3)
                                {
                                    Misc.TopHeader();
                                    Console.WriteLine($"You have selected the {tempParty.Name} Party. \nCurrent Members:");
                                    foreach (Character c in tempParty.PartyMembers)
                                    {
                                        Console.WriteLine($"{i}. {c.Name}");
                                    }
                                    Misc.WriteLine();
                                    Console.WriteLine("Please enter the name of the party member that you wish to remove: ");
                                    tempString = Console.ReadLine();
                                    foreach(Character c in tempParty.PartyMembers)
                                    {
                                        if(c.Name == tempString)
                                        {
                                            tempCharacter = c;
                                            isContained = true;
                                        }
                                    }
                                    if (isContained)
                                    {
                                        tempParty.PartyMembers.Remove(tempCharacter);
                                        Console.WriteLine($"{tempCharacter.Name} removed from {tempParty.Name}!");
                                        Misc.WriteLine();
                                        whileLoopBool3 = Misc.Continue("removing characters");
                                    }
                                }
                                break;
                        }
                        whileLoopBool2 = Misc.Continue("editing this party");
                    }
                }
                else
                {
                    Console.WriteLine("You have entered an incorrect party name, please try again...\n");
                    Console.ReadKey();
                }
                whileLoopBool = Misc.Continue("editing any parties");
            }
        }


        public static void CreateParty()
        {
            bool isContained;
            bool isPlayerParty = false;
            string tempString;
            List<Character> PartyMembers = new List<Character>();
            string PartyName;
            bool tempBool = true;
            Console.Clear();
            Misc.TopHeader();
            Console.WriteLine("Welcome to the party creator. ");
            Console.WriteLine("Would you like to create a party?: (Y/N) ");
            ConsoleKey enterKey = Console.ReadKey().Key;
            if (enterKey != ConsoleKey.Y)
            {
                Program.MainMenu();
            }
            Misc.TopHeader();
            Console.WriteLine("Is this a player party? (Y/N): ");
            while (tempBool)
            {
                ConsoleKey temp = Console.ReadKey().Key;
                if(temp == ConsoleKey.Y)
                {
                    tempBool = false;
                    isPlayerParty = true;
                }else if(temp == ConsoleKey.N)
                {
                    tempBool = false;
                    isPlayerParty = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input, please try again: ");
                }
            }
            Misc.TopHeader();
            Console.WriteLine("Please enter a party name: ");
            PartyName = Console.ReadLine();
            while (!tempBool)
            {
                Misc.TopHeader();
                Console.WriteLine("Please add characters to the party.\nAvailable Characters: ");
                Misc.DisplayAllCharacters();
                if(Character.Dictionary.Count == 0)
                {
                    Console.WriteLine("There are no available characters to add...");
                    Console.ReadKey();
                    Program.MainMenu();
                }
                tempString = Console.ReadLine();
                if (Character.Dictionary.ContainsKey(tempString))
                {
                    PartyMembers.Add(Character.Dictionary[tempString]);
                    isContained = true;
                }
                else
                {
                    if (tempString == "Escape")
                    {
                        Program.MainMenu();
                    }
                    isContained = false;
                    Console.WriteLine("That character does not exist! Please try again: ");
                }
                if (isContained)
                {
                    Console.WriteLine("Would you like to add another character? (Y/N): ");
                    ConsoleKey temp = Console.ReadKey().Key;
                    if (temp == ConsoleKey.N)
                    {
                        tempBool = true;
                    }
                    isContained = false;
                }
            }
            Party.Dictionary.Add(PartyName, new Party(PartyName, isPlayerParty, PartyMembers));
            Misc.TopHeader();
            Console.WriteLine($"Party {PartyName} Created! Press any key to continue...");
            Console.ReadKey();
            Program.MainMenu();
        }
    }
}
