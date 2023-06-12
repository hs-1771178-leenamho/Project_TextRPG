using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SelectJob
{
    public static SELECTPLAYERJOB SelectPlayerJob()
    {
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=================================Text RPG=================================");
            Console.WriteLine("직업을 선택해주세요");
            Console.WriteLine("1. 기사");
            Console.WriteLine("2. 마법사");
            Console.WriteLine("3. 궁수");
            Console.WriteLine("4. 도적");
            ConsoleKeyInfo JobKeyInfo = Console.ReadKey();
            Console.WriteLine("");

            if (JobKeyInfo.Key == ConsoleKey.D1)
            {
                Console.WriteLine("기사로 전직합니다....");
                Console.ReadKey();
                return SELECTPLAYERJOB.KNIGHT;
            }
            else if (JobKeyInfo.Key == ConsoleKey.D2)
            {
                Console.WriteLine("마법사로 전직합니다....");
                Console.ReadKey();
                return SELECTPLAYERJOB.WIZARD;
            }
            else if (JobKeyInfo.Key == ConsoleKey.D3)
            {
                Console.WriteLine("궁수로 전직합니다....");
                Console.ReadKey();
                return SELECTPLAYERJOB.ARCHER;
            }
            else if (JobKeyInfo.Key == ConsoleKey.D4)
            {
                Console.WriteLine("궁수로 전직합니다....");
                Console.ReadKey();
                return SELECTPLAYERJOB.THIEF;
            }
            else
            {
                Console.WriteLine("잘못된 입력");
                Console.ReadKey();
                continue;
            }
        }
    }
}

