using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ShopInven : Inven
{
    Inven S_Inven;
    public Item[] Shop_ArrItem;
    int SelectIdx_S;
    int Shop_X;
    int Shop_Y;

    public ShopInven(Inven _S_Inven) : base(_S_Inven.X, _S_Inven.Y)
    {
        this.S_Inven = _S_Inven;
        this.Shop_ArrItem = _S_Inven.ArrItem;
        this.SelectIdx_S = Inven.SelectIndex;
        this.Shop_X = _S_Inven.X;
        this.Shop_Y = _S_Inven.Y;
    }

    public override void Render()
    {
        this.SelectIdx_S = Inven.SelectIndex;
        for (int i = 0; i < Shop_ArrItem.Length; i++)
        {
            if (i != 0 && i % Shop_X == 0)
            {
                Console.WriteLine("");
            }

            if (SelectIdx_S == i)
            {
                Console.Write("▣");
            }
            else if (Shop_ArrItem[i] == null)
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
        if (SelectIdx_S < Shop_ArrItem.Length)
        {
            if (Shop_ArrItem[SelectIdx_S] == null)
            {
                Console.WriteLine("현재 선택된 슬롯");
                Console.WriteLine("비어있음");
            }
            else
            {
                Console.WriteLine("현재 선택된 슬롯");
                Console.WriteLine("이름 : " + Shop_ArrItem[SelectIdx_S].Name);
                Console.WriteLine("가격 : " + Shop_ArrItem[SelectIdx_S].Gold + "G");
            }
        }
    }

    public override void SelectMoveDown()
    {
        int CheckIdx = SelectIndex;
        CheckIdx += itemX;

        if (OverCheck(CheckIdx)) switchShopAndPlayer = !switchShopAndPlayer;
        SelectIndex += itemX;
    }

    public override void SelectMoveRight()
    {
        int CheckIdx = SelectIndex;
        CheckIdx++;

        if (OverCheck(CheckIdx)) switchShopAndPlayer = !switchShopAndPlayer;
        SelectIndex++;
    }

    public override void ItemPut(Item _Item)
    {
        for (int i = 0; i < Shop_ArrItem.Length; i++)
        {
            if (Shop_ArrItem[i] == null)
            {
                Shop_ArrItem[i] = _Item;
                break;
            }
        }
    }
}

