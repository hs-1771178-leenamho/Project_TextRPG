﻿using System;

class Program
{
    static void Main(string[] args)
    {
        Player newPlayer = new Player();
        newPlayer.Name = "용사";
        Monster[] monsterArr = new Monster[7];
        monsterArr[0] = new Monster("고블린", 20,20, 3, 1);
        monsterArr[1] = new Monster("늑대", 50, 50, 5, 2);
        monsterArr[2] = new Monster("오크", 70, 70, 10, 5);
        monsterArr[3] = new Monster("스켈레톤", 100, 100, 15, 9);
        monsterArr[4] = new Monster("마족", 150, 150, 22, 14);
        monsterArr[5] = new Monster("드래곤", 200, 200, 29, 20);
        monsterArr[6] = new Monster("마왕", 300, 300, 40, 30);

        ShopInven newShopInven = new ShopInven(new Inven(5, 3));

        newShopInven.ItemPut(new Item("목검", 50, 5, 0));
        newShopInven.ItemPut(new Item("가죽갑옷", 60, 0, 8));
        newShopInven.ItemPut(new Item("사슬검", 70, 10, 0));
        newShopInven.ItemPut(new Item("사슬갑옷", 90, 0, 12));
        newShopInven.ItemPut(new Item("철검", 120, 20, 0));
        newShopInven.ItemPut(new Item("철갑옷", 150, 0, 15));
        newShopInven.ItemPut(new Item("미스릴검", 200, 80, 0));
        newShopInven.ItemPut(new Item("미스릴갑옷", 220, 0, 45));
        newShopInven.ItemPut(new Item("아다만티움검", 300, 100, 0));
        newShopInven.ItemPut(new Item("아다만티움갑옷", 350, 0, 60));

        // 마을과 전투존을 나누어서 진행하고자 한다.
        Console.WriteLine("=================================Text RPG=================================");
        STARTSELECT PlayerSelect = STARTSELECT.SELECTJOB;
        SELECTPLAYERJOB PlayerJobSelect = SELECTPLAYERJOB.BEGINNER;

        while (true)
        {
            switch (PlayerSelect)
            {
                case STARTSELECT.SELECTJOB:
                    PlayerJobSelect = SelectJob.SelectPlayerJob();
                    PlayerSelect = STARTSELECT.NONESELECT;
                    newPlayer.PlayerJob = PlayerJobSelect;
                    break;
                case STARTSELECT.SELECTTOWN:
                    PlayerSelect = Town.InTown(newPlayer, newShopInven);
                    break;
                case STARTSELECT.SELECTBATTLEZONE:
                    //Monster newMoster = new Monster("오크", 100, 10, 5);
                    //newMoster.Name = "오크";
                    PlayerSelect = BattleZone.InBattleZone(newPlayer, monsterArr[Monster.stage]);
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

