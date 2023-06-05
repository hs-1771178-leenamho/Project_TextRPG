using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Player : FightUnit
{
    
    PlayerInven _PlayerInven = new PlayerInven(new Inven(5, 3));
    PlayerEquipment _PlayerEquipment = new PlayerEquipment(new Inven(5,1));

    int mDef = 0;

    public int Def
    {
        get
        {
            return this.mDef;
        }
        set
        {
            this.mDef = value;
        }
    }

    public Player()
    {
        this.At += 10;
        this.Def = 5;
    }
    public PlayerInven PInven
    {
        get
        {
            return _PlayerInven;
        }
    }

    public PlayerEquipment PEquip
    {
        get
        {
            return _PlayerEquipment;
        }
    }


    public void setHp()
    {
        this.Hp = 1;
    }

    public override void StatusRender()
    {
        Console.WriteLine("-------------" + this.m_Name + "-------------");
        Console.WriteLine("체력 : " + this.Hp + "/" + this.m_MaxHp);
        Console.WriteLine("공격력 : " + this.At);
        Console.WriteLine("방어력 : " + this.Def);
        Console.WriteLine("------------------------------");
    }

    public void Heal()
    {
        this.Hp += 20;
        if (this.Hp >= this.m_MaxHp)
        {
            this.Hp = this.m_MaxHp;
        }
    }

    public void Upgrade()
    {
        this.At += 10;
    }

    public override void Damage(FightUnit _Other)
    {
        int dmg = 0;
        if (_Other.Hp <= 0)
        {
            return;
        }

        Console.WriteLine(_Other.Name + "의 공격!");
        dmg = _Other.At - this.Def;
        if (dmg <= 0) dmg = 0;
        this.Hp -= dmg;
        Console.ReadKey();
        if (this.Hp <= 0)
        {
            this.Hp = 0;
        }
        Console.WriteLine(this.m_Name + "의 HP : " + this.Hp);
        Console.ReadKey();

        if (this.Hp == 0)
        {
            Console.WriteLine("");
            Console.WriteLine(this.m_Name + "가 쓰러졌습니다.");
            Console.ReadKey();
            Console.WriteLine("전투 종료");
            Console.ReadKey();
        }
    }
}

