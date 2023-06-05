using System;

class Program
{
    static void Main(string[] args)
    {
        Player newPlayer = new Player();
        newPlayer.Name = "용사";

        // 마을과 전투존을 나누어서 진행하고자 한다.
        Console.WriteLine("=================================Text RPG=================================");
        STARTSELECT PlayerSelect = STARTSELECT.NONESELECT;

        while (true)
        {
            switch (PlayerSelect)
            {
                case STARTSELECT.SELECTTOWN:
                    PlayerSelect = Town.InTown(newPlayer);
                    break;
                case STARTSELECT.SELECTBATTLEZONE:
                    Monster newMoster = new Monster("오크", 100, 10, 5);
                    //newMoster.Name = "오크";
                    PlayerSelect = BattleZone.InBattleZone(newPlayer, newMoster);
                    break;
                case STARTSELECT.NONESELECT:
                    PlayerSelect = Start.StartSelect();
                    break;
                case STARTSELECT.SELECTEND:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

    }
}

