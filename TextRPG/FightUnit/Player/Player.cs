using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Player : FightUnit
{
    private static Player _player; // 싱글톤
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

    private Player()
    {
        this.Hp = this.MaxHp;
        this.At = 10;
        this.Def = 5;
    }

    public static Player Instance()
    {
        if(_player == null)
        {
            _player = new Player();
        }
        return _player;
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
        switch (this.PlayerJob)
        {
            case SELECTPLAYERJOB.NONSELECT:
                break;
            case SELECTPLAYERJOB.BEGINNER:
                break;
            case SELECTPLAYERJOB.KNIGHT:
                Console.WriteLine("직업 : 기사");
                break;
            case SELECTPLAYERJOB.WIZARD:
                Console.WriteLine("직업 : 마법사");
                break;
            case SELECTPLAYERJOB.ARCHER:
                Console.WriteLine("직업 : 궁수");
                break;
            case SELECTPLAYERJOB.THIEF:
                Console.WriteLine("직업 : 도적");
                break;
            default:
                break;
        }
        
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

    public void Calculate_STAT(Item item)
    {
        
        if(item.ItemType == ITEMTYPE.ARMOR)
        {
            this.Def += item.ItemDef;
            
        }

        // 직업과 아이템 타입이 일치하면 공격력 그대로, 다르면 공격력 마이너스
        else if(this.PlayerJob == SELECTPLAYERJOB.KNIGHT)
        {
            if(item.ItemType == ITEMTYPE.FORKNIGHT)
            {
                this.At += item.ItemAt;
            }
            else
            {
                this.At += item.ItemAt - 5;
                
            }
        }
        else if(this.PlayerJob == SELECTPLAYERJOB.WIZARD)
        {
            if (item.ItemType == ITEMTYPE.FORWIZARD)
            {
                this.At += item.ItemAt;
            }
            else
            {
                this.At += item.ItemAt - 5;
               
            }
        }
        else if(this.PlayerJob == SELECTPLAYERJOB.ARCHER)
        {
            if (item.ItemType == ITEMTYPE.FORARCHER)
            {
                this.At += item.ItemAt;
            }
            else
            {
                this.At += item.ItemAt - 5;
                
            }
        }
        else if(this.PlayerJob == SELECTPLAYERJOB.THIEF)
        {
            if (item.ItemType == ITEMTYPE.FORTHIEF)
            {
                this.At += item.ItemAt;
            }
            else
            {
                this.At += item.ItemAt - 5;
                
            }
        }

        
    }

    

}

