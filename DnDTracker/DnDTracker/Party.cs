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
            throw new NotImplementedException();
        }

        internal static void CreateParty()
        {
            bool isPlayerParty;
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
            Misc.TopHeader();
            Console.WriteLine("Please add characters to the party.\nAvailable Characters: ");
            Misc.DisplayAllCharacters();
        }
    }
}
