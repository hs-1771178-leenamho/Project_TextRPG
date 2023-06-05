using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Monster : FightUnit
{
    //public Monster(String name)
    //{
    //    this.m_Name = name;
    //}
    public static int stage = 0;
    public Monster(string _Name, int _Hp ,int _At, int _Def)
    {
        this.Name = _Name;
        this.Hp = _Hp;
        this.At = _At;
        this.Def = _Def;
    }


}
