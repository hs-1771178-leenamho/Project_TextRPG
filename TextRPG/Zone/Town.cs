using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Town
{
    static void Equipment(Player _player)
    {

    }
    static void Shop(Player _player, ShopInven _ShopInven)
    {
        Inven.SelectIndex = 0;
        bool stay_Shop = true;
        while (stay_Shop)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("상점 물건 목록");
            _ShopInven.Render();
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("플레이어 인벤토리");
            _player.PInven.Render();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("칸 이동하기 : 방향키");
            Console.WriteLine("아이템 선택하기 : Enter");
            Console.WriteLine("상점 나가기 : ESC");
            Console.WriteLine("");
            Console.WriteLine("구매하거나 팔려는 아이템 칸으로 이동해 Enter를 이용해 집고 옮기고자 하는 칸으로 옮기세요");
            ConsoleKeyInfo ShopKeyInfo = Console.ReadKey();

            switch (ShopKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:
                    if (Inven.SelectIndex < _ShopInven.InvenSize())
                    {
                        _ShopInven.SelectMove(Console.ReadKey());
                    }
                    else
                    {
                        _player.PInven.SelectMove(Console.ReadKey());
                    }
                    break;
                case ConsoleKey.Enter:
                    _player.PInven.SelectItem();
                    break;
                case ConsoleKey.Escape:
                    Console.WriteLine("");
                    Console.WriteLine("ㅁ문을 열고 상점을 나갑니다..");
                    //Console.ReadKey();
                    stay_Shop = false;
                    break;
                default:
                    break;
            }



        }
    }

    public static STARTSELECT InTown(Player player)
    {
        ShopInven shopInven = new ShopInven(new Inven(5, 3));

        shopInven.ItemPut(new Item("철검", 500));
        shopInven.ItemPut(new Item("갑옷", 700));
        shopInven.ItemPut(new Item("지도", 100));
        shopInven.ItemPut(new Item("체력 포션", 150));
        shopInven.ItemPut(new Item("횃불", 50));

        player.PInven.SetShopInven(shopInven);
        

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=================================Text RPG=================================");
            Console.WriteLine("");
            int p_hp = player.getHp();
            if (p_hp == 0) player.setHp();
            player.StatusRender();
            Console.WriteLine("");
            Console.WriteLine("마을에 들어섰습니다.");
            Console.WriteLine("어떤 행동을 취할지 정해주세요.");
            Console.WriteLine("");
            Console.WriteLine("1. 여관에서 휴식한다.");
            Console.WriteLine("2. 상점에 방문한다.");
            Console.WriteLine("3. 장비를 확인한다.");
            Console.WriteLine("4. 마을을 떠난다.");
            ConsoleKeyInfo TownkeyInfo = Console.ReadKey();
            Console.WriteLine("");

            if (TownkeyInfo.Key == ConsoleKey.D1)
            {
                Console.WriteLine("지친 몸을 이끌고 여관으로 향합니다....");
                Console.ReadKey();
                Console.WriteLine("");
                Console.WriteLine("여관에서 충분한 휴식을 취해 체력을 회복했습니다.");
                Console.WriteLine("");
                player.Heal();
                player.StatusRender();
                Console.ReadKey();

            }
            else if (TownkeyInfo.Key == ConsoleKey.D2)
            {
                Console.WriteLine("마을에서 가장 큰 상점을 방문합니다....");
                Console.ReadKey();
                Console.WriteLine("");
                Shop(player, shopInven);
                Console.ReadKey();
            }
            else if (TownkeyInfo.Key == ConsoleKey.D3)
            {
                Console.WriteLine("현재 착용하고 있는 장비를 확인합니다....");
                Console.ReadKey();
                Console.WriteLine("");
                //Shop(player, shopInven);
                Equipment(player);
                Console.ReadKey();
            }
            else if (TownkeyInfo.Key == ConsoleKey.D4)
            {
                Console.WriteLine("마을을 떠납니다....");
                Console.ReadKey();
                return STARTSELECT.NONESELECT;
            }
        }
    }
}

