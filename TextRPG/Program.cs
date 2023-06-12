using System;

class Program
{
    static void Main(string[] args)
    {
        Player newPlayer = Player.Instance();
        newPlayer.Name = "용사";
        #region Monster Setting
        Monster[] monsterArr = new Monster[7];
        monsterArr[0] = new Monster("고블린", 20,20, 3, 1);
        monsterArr[1] = new Monster("늑대", 50, 50, 5, 2);
        monsterArr[2] = new Monster("오크", 70, 70, 10, 5);
        monsterArr[3] = new Monster("스켈레톤", 100, 100, 15, 9);
        monsterArr[4] = new Monster("마족", 150, 150, 22, 14);
        monsterArr[5] = new Monster("드래곤", 200, 200, 29, 20);
        monsterArr[6] = new Monster("마왕", 300, 300, 40, 30);
        #endregion

        #region ShopInven Setting
        ShopInven[] shopInvenArr = new ShopInven[7];
        shopInvenArr[0] = new ShopInven(new Inven(5, 3)); // 최초 초보자 세트
        shopInvenArr[1] = new ShopInven(new Inven(5, 3)); // 고블린 잡은 후
        shopInvenArr[2] = new ShopInven(new Inven(5, 3)); // 늑대 잡은 후
        shopInvenArr[3] = new ShopInven(new Inven(5, 3)); // 오크 잡은 후
        shopInvenArr[4] = new ShopInven(new Inven(5, 3)); // 스켈레톤 잡은 후
        shopInvenArr[5] = new ShopInven(new Inven(5, 3)); // 마족 잡은 후
        shopInvenArr[6] = new ShopInven(new Inven(5, 3)); // 드래곤 잡은 후

        shopInvenArr[0].ItemPut(new Item("목검", ITEMTYPE.FORKNIGHT,50, 5, 0));
        shopInvenArr[0].ItemPut(new Item("낡은 나무 지팡이", ITEMTYPE.FORWIZARD,50, 5, 0));
        shopInvenArr[0].ItemPut(new Item("낡은 활", ITEMTYPE.FORARCHER,50, 5, 0));
        shopInvenArr[0].ItemPut(new Item("녹슨 단검", ITEMTYPE.FORTHIEF,50, 5, 0));
        shopInvenArr[0].ItemPut(new Item("천 갑옷", ITEMTYPE.ARMOR,50, 0, 3));

        shopInvenArr[1].ItemPut(new Item("돌검", ITEMTYPE.FORKNIGHT, 50, 5, 0));
        shopInvenArr[1].ItemPut(new Item("나무 지팡이", ITEMTYPE.FORWIZARD, 50, 5, 0));
        shopInvenArr[1].ItemPut(new Item("고블린 활", ITEMTYPE.FORARCHER, 50, 5, 0));
        shopInvenArr[1].ItemPut(new Item("고블린 단검", ITEMTYPE.FORTHIEF, 50, 5, 0));
        shopInvenArr[1].ItemPut(new Item("고블린 가죽갑옷", ITEMTYPE.ARMOR, 50, 0, 3));

        shopInvenArr[2].ItemPut(new Item("철검", ITEMTYPE.FORKNIGHT, 50, 5, 0));
        shopInvenArr[2].ItemPut(new Item("늑대 뿔 지팡이", ITEMTYPE.FORWIZARD, 50, 5, 0));
        shopInvenArr[2].ItemPut(new Item("장궁", ITEMTYPE.FORARCHER, 50, 5, 0));
        shopInvenArr[2].ItemPut(new Item("늑대 이빨 단검", ITEMTYPE.FORTHIEF, 50, 5, 0));
        shopInvenArr[2].ItemPut(new Item("늑대 가죽갑옷", ITEMTYPE.ARMOR, 50, 0, 3));

        shopInvenArr[3].ItemPut(new Item("오크의 몽둥이", ITEMTYPE.FORKNIGHT, 50, 5, 0));
        shopInvenArr[3].ItemPut(new Item("오동 나무 지팡이", ITEMTYPE.FORWIZARD, 50, 5, 0));
        shopInvenArr[3].ItemPut(new Item("강화된 활", ITEMTYPE.FORARCHER, 50, 5, 0));
        shopInvenArr[3].ItemPut(new Item("오크 송곳니 단검", ITEMTYPE.FORTHIEF, 50, 5, 0));
        shopInvenArr[3].ItemPut(new Item("철갑옷", ITEMTYPE.ARMOR, 50, 0, 3));

        shopInvenArr[4].ItemPut(new Item("본소드", ITEMTYPE.FORKNIGHT, 50, 5, 0));
        shopInvenArr[4].ItemPut(new Item("스켈레톤 주술사 지팡이", ITEMTYPE.FORWIZARD, 50, 5, 0));
        shopInvenArr[4].ItemPut(new Item("곡궁", ITEMTYPE.FORARCHER, 50, 5, 0));
        shopInvenArr[4].ItemPut(new Item("본 대거", ITEMTYPE.FORTHIEF, 50, 5, 0));
        shopInvenArr[4].ItemPut(new Item("강철갑옷", ITEMTYPE.ARMOR, 50, 0, 3));

        shopInvenArr[5].ItemPut(new Item("마검", ITEMTYPE.FORKNIGHT, 50, 5, 0));
        shopInvenArr[5].ItemPut(new Item("다크 스태프", ITEMTYPE.FORWIZARD, 50, 5, 0));
        shopInvenArr[5].ItemPut(new Item("마궁", ITEMTYPE.FORARCHER, 50, 5, 0));
        shopInvenArr[5].ItemPut(new Item("블랙 본 나이프", ITEMTYPE.FORTHIEF, 50, 5, 0));
        shopInvenArr[5].ItemPut(new Item("미스릴 갑옷", ITEMTYPE.ARMOR, 50, 0, 3));

        shopInvenArr[6].ItemPut(new Item("드래곤 소드", ITEMTYPE.FORKNIGHT, 50, 5, 0));
        shopInvenArr[6].ItemPut(new Item("오리할콘 스태프", ITEMTYPE.FORWIZARD, 50, 5, 0));
        shopInvenArr[6].ItemPut(new Item("드래곤 킬링 보우", ITEMTYPE.FORARCHER, 50, 5, 0));
        shopInvenArr[6].ItemPut(new Item("드래고니아 나이프", ITEMTYPE.FORTHIEF, 50, 5, 0));
        shopInvenArr[6].ItemPut(new Item("용비늘 갑주", ITEMTYPE.ARMOR, 50, 0, 3));

        #endregion
        
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
                    PlayerSelect = Town.InTown(newPlayer, shopInvenArr[ShopInven.shop_Stage]);
                    break;
                case STARTSELECT.SELECTBATTLEZONE:
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

