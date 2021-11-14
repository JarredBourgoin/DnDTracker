using System.Collections.Generic;

namespace DnDTracker
{
    class Player
    {
        //AS PLAYER
        public string Name { get; private set; }
        public int TotalDamageDone { get; set; }
        public int TotalHealingDone { get; set; }
        public int HighestDamageDone { get; set; }
        public int KillCount { get; set; }
        public int Deaths { get; set; }
        public bool PKer { get; set; }
        public List<string> Characters { get; set; }
        public int MagicItemsFound { get; set; }
        //AS DM
        public int TotalDamageDoneAsDM { get; set; }
        public int HighestDamageDoneAsDM { get; set; }
        public int PlayersKilled { get; set; }
        public int PlayersDowned { get; set; }
        public int MagicItemsRewarded { get; set; }
        //Constructor
        public Player(string name, int damageAsPlayer = 0, int healingAsPlayer = 0, int highestDamageAsPlayer = 0, int killCount = 0,
            int deaths = 0, bool pk = false, int magicFound = 0, int damageAsDm = 0, int highestDamageAsDm = 0, int playersKilled = 0, int playersDowned = 0, int magicItemsRewarded = 0)
        {
            Name = name;
            TotalDamageDone = damageAsPlayer;
            TotalHealingDone = healingAsPlayer;
            HighestDamageDone = highestDamageAsPlayer;
            KillCount = killCount;
            Deaths = deaths;
            PKer = pk;
            MagicItemsFound = magicFound;
            TotalDamageDoneAsDM = damageAsDm;
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
            PKer = false;
            MagicItemsFound = 0;
            TotalDamageDoneAsDM = 0;
            PlayersKilled = 0;
            PlayersDowned = 0;
            MagicItemsRewarded = 0;
        }
    }
}
