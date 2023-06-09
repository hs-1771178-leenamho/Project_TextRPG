using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Town
{
    static void Equipment(Player _player)
    {
        _player.PEquip.SetEquip(_player.PInven);
        _player.PInven.SetPlayerEquipment(_player.PEquip);

        int[] equipCalArr = new int[2];
        int[] firstStat = new int[2];
        int firstAt = _player.At;
        int firstDef = _player.Def;
        firstStat[0] = firstAt;
        firstStat[1] = firstDef;

        Inven.SelectIndex = 0;
        //Inven.switchInvenMove = false;
        bool stay_equip = true;
        while (stay_equip)
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine("착용 중인 장비 목록");
            Console.WriteLine("");
            _player.PEquip.Render();
            Console.WriteLine("");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            
            Console.WriteLine("플레이어 인벤토리 목록");
            Console.WriteLine("");
            _player.PInven.RenderForE();
            Console.WriteLine("");
            _player.StatusRender();
            Console.WriteLine("");
            Console.WriteLine("커서 옮기기 : 방향키");
            Console.WriteLine("아이템 선택하기 : Enter");
            Console.WriteLine("");
            Console.WriteLine("아이템을 선택해 착용 가능");
            Console.WriteLine("");
            ConsoleKeyInfo ShopKeyInfo = Console.ReadKey();

            switch (ShopKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:
                    if (Inven.SelectIndex < _player.PEquip.InvenSize())
                    {
                        _player.PEquip.SelectMove(Console.ReadKey());
                    }
                    else
                    {
                        _player.PInven.SelectMoveInEquip(Console.ReadKey());
                    }
                    break;
                case ConsoleKey.Enter:
                    _player.PInven.SelectEquipItem();
                    break;
                case ConsoleKey.Escape:
                    Console.WriteLine("");
                    Console.WriteLine("ㅁ장비 확인을 끝마칩니다..");
                    //Console.ReadKey();
                    stay_equip = false;
                    break;
                default:
                    break;
            }
            
            equipCalArr = _player.PEquip.Calcul_Equip();

            _player.At = firstStat[0] + equipCalArr[0];
            _player.Def = firstStat[1] + equipCalArr[1];

        }
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
                    _player.PInven.SelectShopItem();
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

    public static STARTSELECT InTown(Player player, ShopInven shopInven)
    {
        
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

