using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BattleZone
{
    public static STARTSELECT InBattleZone(Player player, Monster monster)
    {
        while (!player.isDeath() && !monster.isDeath())
        {
            Console.Clear();
            Console.WriteLine("=================================Text RPG=================================");
            Console.WriteLine("");
            player.StatusRender();
            Console.WriteLine("");
            monster.StatusRender();
            Console.WriteLine("");

            player.Damage(monster);
            Console.WriteLine("");
            monster.Damage(player);
        }
        if (monster.isDeath())
        {
            player.PInven.Gold += 100;
        }
        Console.WriteLine("");
        Console.WriteLine("전투가 끝났습니다.");
        Console.WriteLine("피에 젖은 몸을 이끌고 마을로 향합니다....");
        Console.ReadKey();

        return STARTSELECT.SELECTTOWN;
    }
}

