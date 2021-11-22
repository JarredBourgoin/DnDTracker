using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DnDTracker
{
    class Campaign
    {
        public string SaveName { get; set; }
        public List<Character> AllCurrentCharacters { get; set; }
        public List<Monster> AllCurrentMonsters { get; set; }
        public List<Player> AllCurrentPlayers { get; set; }
        public List<Party> AllCurrentParties { get; set; }

        public Campaign(string name)
        {
            SaveName = name;
            throw new NotImplementedException();
        }

    }
}
