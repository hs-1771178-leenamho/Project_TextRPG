using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PlayerEquipment : Inven
{
    Inven _P_EInven;
    public Item[] Equip_Arr;
    Item selectedItem_E;
    PlayerInven mPlayerInven;
    public bool switchEquipMove;
    public PlayerInven PlayerInven
    {
        get
        {
            return this.mPlayerInven;
        }
        set
        {
            this.mPlayerInven = value;
        }
    }
    int _P_E_X;
    int _P_E_Y;
    int SelectIdx_E;

    public PlayerEquipment(Inven _P_Inven) : base(_P_Inven.X, _P_Inven.Y)
    {
        this._P_EInven = _P_Inven;
        this._P_E_X = _P_Inven.X;
        this._P_E_Y = _P_Inven.Y;
        this.SelectIdx_E = Inven.SelectIndex;
        this.Equip_Arr = _P_Inven.ArrItem;
        this.switchEquipMove = false;
    }
    
    public void SetEquip(PlayerInven _PlayerInven)
    {
        this.PlayerInven = _PlayerInven;
    }

    public override void Render()
    {
        this.SelectIdx_E = Inven.SelectIndex;
        for (int i = 0; i < Equip_Arr.Length; i++)
        {
            if (i != 0 && i % itemX == 0)
            {
                Console.WriteLine("");
            }

            if (SelectIdx_E == i)
            {
                Console.Write("▣");
            }
            else if (Equip_Arr[i] == null)
            {
                Console.Write("□");
            }
            else
            {
                Console.Write("■");
            }
        }

        Console.WriteLine("");
        Console.WriteLine("");
        if (selectedItem_E != null)
        {
            Console.WriteLine("선택한 아이템 : " + selectedItem_E.Name);           
            Console.WriteLine("");
        }
        if (SelectIdx_E >= 0 && SelectIdx_E < _P_E_X * _P_E_Y)
        {
            if (Equip_Arr[SelectIdx_E] == null)
            {
                Console.WriteLine("현재 선택된 슬롯");
                Console.WriteLine("비어있음");
            }
            else
            {
                Console.WriteLine("현재 선택된 슬롯");
                Console.WriteLine("이름 : " + Equip_Arr[SelectIdx_E].Name);
                Console.WriteLine("공격력 : " + Equip_Arr[SelectIdx_E].ItemAt);
                Console.WriteLine("방어력 : " + Equip_Arr[SelectIdx_E].ItemDef);
                switch (Equip_Arr[SelectIdx_E].ItemType)
                {
                    case ITEMTYPE.FORKNIGHT:
                        Console.WriteLine("아이템 타입 : 기사 무기");
                        break;
                    case ITEMTYPE.FORWIZARD:
                        Console.WriteLine("아이템 타입 : 마법사 무기");
                        break;
                    case ITEMTYPE.FORARCHER:
                        Console.WriteLine("아이템 타입 : 궁수 무기");
                        break;
                    case ITEMTYPE.FORTHIEF:
                        Console.WriteLine("아이템 타입 : 도적 무기");
                        break;
                    case ITEMTYPE.ARMOR:
                        Console.WriteLine("아이템 타입 : 방어구");
                        break;
                    default:
                        break;
                }
            }
        }
    }
    public override bool OverCheck(int _SelectIndex)
    {
        if ((_SelectIndex >= 0 && _SelectIndex < ArrItem.Length) && !switchEquipMove)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public override void SelectMoveUp()
    {
        int CheckIdx = SelectIndex;
        CheckIdx -= _P_E_X;

        if (OverCheck(CheckIdx))
        {
            return;
        }

        SelectIndex -= _P_E_X;
    }

    public override void SelectMoveDown()
    {
        int CheckIdx = SelectIndex;
        CheckIdx += _P_E_X;

        if (OverCheck(CheckIdx))
        {
            switchEquipMove = !switchEquipMove;
            //return;
        }

        SelectIndex += _P_E_X;
    }

    public override void SelectMoveLeft()
    {
        int CheckIdx = SelectIndex;
        CheckIdx--;

        if (OverCheck(CheckIdx))
        {
            return;
        }

        SelectIndex--;
    }

    public override void SelectMoveRight()
    {
        int CheckIdx = SelectIndex;
        CheckIdx++;

        if (OverCheck(CheckIdx))
        {
            switchEquipMove = !switchEquipMove;
            //return;
        }

        SelectIndex++;
    }
    
}

