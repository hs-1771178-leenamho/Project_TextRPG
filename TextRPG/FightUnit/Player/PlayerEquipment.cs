using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PlayerEquipment : Inven
{
    Inven _P_EInven;
    Item[] Equip_Arr;
    Item selectedItem_E;
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
    }

    public override void Render()
    {
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
            }
        }
    }

    public void SelectItem_E()
    {

    }
}

