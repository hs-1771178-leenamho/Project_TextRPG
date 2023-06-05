using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FightUnit
{
    protected String m_Name = "None";
    protected int mAt = 10;
    protected int mHp = 50;
    protected int m_MaxHp = 100;
    public int Hp
    {
        get
        {
            return mHp;
        }
        set
        {
            this.mHp = value;
        }
    }

    public int At
    {
        get
        {
            return mAt;
        }
        set
        {
            this.mAt = value;
        }
    }

    public int MaxHp
    {
        get
        {
            return m_MaxHp;
        }
        set
        {
            m_MaxHp = value;
        }
    }

    public string Name
    {
        get
        {
            return m_Name;
        }
        set
        {
            m_Name = value;
        }
    }

    public virtual void StatusRender()
    {
        Console.WriteLine("-------------" + this.m_Name + "-------------");
        Console.WriteLine("체력 : " + this.Hp + "/" + this.m_MaxHp);
        Console.WriteLine("공격력 : " + this.At);
        Console.WriteLine("------------------------------");
    }

    public int getHp()
    {
        return this.Hp;
    }

    public bool isDeath()
    {
        return this.Hp <= 0;
    }

    public void Damage(FightUnit _Other) // 나를 _Other가 때린다!
    {
        if (_Other.Hp <= 0)
        {
            return;
        }

        Console.WriteLine(_Other.m_Name + "의 공격!");
        this.Hp -= _Other.At;
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

