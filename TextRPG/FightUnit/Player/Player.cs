using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Player : FightUnit
{
    
    PlayerInven _PlayerInven = new PlayerInven(new Inven(5, 3));
    PlayerEquipment _PlayerEquipment = new PlayerEquipment(new Inven(5,1));
    SELECTPLAYERJOB mPlayerJob = SELECTPLAYERJOB.NONSELECT;

    public SELECTPLAYERJOB PlayerJob
    {
        get
        {
            return mPlayerJob;
        }
        set
        {
            this.mPlayerJob = value;
        }
    }

    public Player()
    {
        this.Hp = this.MaxHp;
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

    public void Calculate_AT()
    {
        if(this.PlayerJob == SELECTPLAYERJOB.KNIGHT)
        {

        }
        else if(this.PlayerJob == SELECTPLAYERJOB.WIZARD)
        {

        }
        else if(this.PlayerJob == SELECTPLAYERJOB.ARCHER)
        {

        }
        else if(this.PlayerJob == SELECTPLAYERJOB.THIEF)
        {

        }
    }

    

}

