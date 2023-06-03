using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Start
{
    public static STARTSELECT StartSelect()
    {
        Console.Clear();
        Console.WriteLine("=================================Text RPG=================================");
        Console.WriteLine("이동할 지역을 골라주세요.");
        Console.WriteLine("1. 마을로 가기");
        Console.WriteLine("2. 사냥터로 가기");
        Console.WriteLine("3. 게임 종료");
        ConsoleKeyInfo StartKeyInfo = Console.ReadKey();
        Console.WriteLine("");

        if (StartKeyInfo.Key == ConsoleKey.D1)
        {
            Console.WriteLine("마을로 향한다....");
            Console.ReadKey();
            return STARTSELECT.SELECTTOWN;
        }
        else if (StartKeyInfo.Key == ConsoleKey.D2)
        {
            Console.WriteLine("사냥터로 향한다....");
            Console.ReadKey();
            return STARTSELECT.SELECTBATTLEZONE;
        }
        else if (StartKeyInfo.Key == ConsoleKey.D3)
        {
            Console.WriteLine("게임을 종료합니다");
            Console.ReadKey();
            return STARTSELECT.SELECTEND;
        }
        else
        {
            Console.WriteLine("잘못된 입력");
            Console.ReadKey();
            return STARTSELECT.NONESELECT;
        }

    }
}
