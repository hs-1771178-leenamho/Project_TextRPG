using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Player : FightUnit
{
    public Player(){
        this.At += 10;
    }
    PlayerInven _PlayerInven = new PlayerInven(new Inven(5, 3));
    PlayerEquipment _PlayerEquipment = new PlayerEquipment(new Inven(5,1));

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
}

