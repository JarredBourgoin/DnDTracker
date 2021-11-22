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
        public Party(string name, bool j)
        {
            Name = name;
            IsPlayerParty = j;
            NumberOfMembers = PartyMembers.Count;
            NumberOfMembersAlive = PartyMembers.Count;
            foreach (Character i in PartyMembers)
            {
                if (i.CurrentHP < 1) { NumberOfMembersAlive -= 1; }
            }
        }

        public static bool AddCharacter(Character c, Party p)
        {
            try
            {
                p.PartyMembers.Add(c);
            }
            catch
            {
                return false;
            }
            p.NumberOfMembers += 1;
            p.NumberOfMembersAlive += 1;
            int temp = p.PartyMembers.IndexOf(c);
            if (p.PartyMembers[temp].CurrentHP < 1)
            {
                p.NumberOfMembersAlive -= 1;
            }
            return true;
        }

        public static void Initialize()
        {

        }

        public static void CreateParty()
        {
            throw new NotImplementedException();
        }
    }
}
