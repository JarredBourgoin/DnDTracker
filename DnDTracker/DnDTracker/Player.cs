using System;
using System.Collections.Generic;


namespace DnDTracker
{
    class Player
    {
        //STATIC
        public static Dictionary<string, Player> Dictionary = new Dictionary<string, Player>();
        //
        public double AverageD20Roll { get; set; }
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
        public int PlayersKilledAsDM { get; set; }
        public int PlayersDowned { get; set; }
        public int MagicItemsRewarded { get; set; }
        //Constructor
        public Player(string name, int damageAsPlayer = 0, int healingAsPlayer = 0, int highestDamageAsPlayer = 0, int killCount = 0,
            int deaths = 0, bool pk = false, int magicFound = 0, int damageAsDm = 0, int highestDamageAsDm = 0, int playersKilled = 0, int playersDowned = 0, int magicItemsRewarded = 0, int playersRevived = 0, int playersPickedUp = 0, int totalDamageTaken = 0, double averageDiceRoll = 10)
        {
            //MISC
            Name = name;
            Deaths = deaths;
            MagicItemsTaken = magicFound;
            Characters = new List<string>();
            AverageD20Roll = averageDiceRoll;
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
            PlayersKilledAsDM = playersKilled;
            PlayersDowned = playersDowned;
            MagicItemsRewarded = magicItemsRewarded;
        }

        public Player(string name)
        {
            Name = name;
            Deaths = 0;
            MagicItemsTaken = 0;
            Characters = new List<string>();
            AverageD20Roll = 10;
            //DAMAGE/KILLS
            TotalDamageDone = 0;
            HighestDamageDone = 0;
            KillCount = 0;
            PlayerKiller = false;
            //HEALING/TANKING
            PlayersRevived = 0;
            PlayersPickedUp = 0;
            TotalHealingDone = 0;
            TotalDamageTaken = 0;
            //AS DM
            TotalDamageDoneAsDM = 0;
            HighestDamageDoneAsDM = 0;
            PlayersKilledAsDM = 0;
            PlayersDowned = 0;
            MagicItemsRewarded = 0;
        }

        public static void CreatePlayer()
        {
            string Name = "name";
            Console.Clear();
            Misc.TopHeader();
            Console.WriteLine("Welcome to the Player Creator. ");
            Console.WriteLine("Would you like to create a Player?: (Y/N) ");
            ConsoleKey enterKey = Console.ReadKey().Key;
            if (enterKey != ConsoleKey.Y)
            {
                Program.MainMenu();
            }
            Console.WriteLine("Please enter the player's name.: ");
            Name = Console.ReadLine();
            Player.Dictionary.Add(Name, new Player(Name));
            Console.WriteLine($"Player {Name} Created! Press any key to continue...");
            Console.ReadKey();
            Program.MainMenu();
        }

        internal static void EditPlayer()
        {
            Misc.TopHeader();
        }
    }
}
