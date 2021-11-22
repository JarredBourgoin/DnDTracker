﻿using System;
using System.Collections.Generic;


namespace DnDTracker
{
    class Player
    {
        //STATIC
        public static Dictionary<string, Player> Dictionary = new Dictionary<string, Player>();
        //
        public List<string> Characters { get; set; }
        //AS PLAYER
        public string Name { get; private set; }
        public int TotalDamageDone { get; set; }
        public int TotalHealingDone { get; set; }
        public int HighestDamageDone { get; set; }
        public int KillCount { get; set; }
        public int TotalDamageTaken { get; set; }
        public int Deaths { get; set; }
        public bool PlayerKiller { get; set; }
        public int MagicItemsTaken { get; set; }
        public int PlayersPickedUp { get; set; }
        public int PlayersRevived { get; set; }
        //AS DM
        public int TotalDamageDoneAsDM { get; set; }
        public int HighestDamageDoneAsDM { get; set; }
        public int PlayersKilled { get; set; }
        public int PlayersDowned { get; set; }
        public int MagicItemsRewarded { get; set; }
        //Constructor
        public Player(string name, int damageAsPlayer = 0, int healingAsPlayer = 0, int highestDamageAsPlayer = 0, int killCount = 0,
            int deaths = 0, bool pk = false, int magicFound = 0, int damageAsDm = 0, int highestDamageAsDm = 0, int playersKilled = 0, int playersDowned = 0, int magicItemsRewarded = 0, int playersRevived = 0, int playersPickedUp = 0, int totalDamageTaken = 0)
        {
            //MISC
            Name = name;
            Deaths = deaths;
            MagicItemsTaken = magicFound;
            Characters = new List<string>();
            //DAMAGE/KILLS
            TotalDamageDone = damageAsPlayer;
            HighestDamageDone = highestDamageAsPlayer;
            KillCount = killCount;
            PlayerKiller = pk;
            //HEALING/TANKING
            PlayersRevived = playersRevived;
            PlayersPickedUp = playersPickedUp;
            TotalHealingDone = healingAsPlayer;
            TotalDamageTaken = totalDamageTaken;
            //AS DM
            TotalDamageDoneAsDM = damageAsDm;
            HighestDamageDoneAsDM = highestDamageAsDm;
            PlayersKilled = playersKilled;
            PlayersDowned = playersDowned;
            MagicItemsRewarded = magicItemsRewarded;

        }

        public Player(string name)
        {
            Name = name;
            TotalDamageDone = 0;
            TotalHealingDone = 0;
            HighestDamageDone = 0;
            KillCount = 0;
            Deaths = 0;
            PlayerKiller = false;
            MagicItemsTaken = 0;
            TotalDamageDoneAsDM = 0;
            PlayersKilled = 0;
            PlayersDowned = 0;
            MagicItemsRewarded = 0;
        }

        public static void CreatePlayer()
        {
            throw new NotImplementedException();
        }

    }
}
