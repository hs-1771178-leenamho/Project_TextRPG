using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PlayerInven : Inven
{
    Inven P_Inven;
    Item[] Player_ArrItem;
    Item selectedItem;
    ShopInven mshopInven;
    ShopInven shopInven {
        get
        {
            return this.mshopInven;
        }
        set
        {
            this.mshopInven = value;
        }
    }
    
    int SelectIdx_P;
    int Player_X;
    int Player_Y;
    int mGold = 100;
    public int Gold
    {
        get
        {
            return mGold;
        }
        set
        {
            this.mGold = value;
        }
    }
    bool To_Buy_Item = false;
    bool To_Sell_Item = false;
    int selectedItemNumber = -1;

    public void SetShopInven(ShopInven S_Inven)
    {
        this.shopInven = S_Inven;
    }

    public PlayerInven(Inven _P_Inven) : base(_P_Inven.X, _P_Inven.Y)
    {
        this.P_Inven = _P_Inven;
        this.Player_ArrItem = _P_Inven.ArrItem;
        this.SelectIdx_P = Inven.SelectIndex - (_P_Inven.X * _P_Inven.Y);
        this.Player_X = _P_Inven.X;
        this.Player_Y = _P_Inven.Y;
    }

    public override void Render()
    {
        this.SelectIdx_P = Inven.SelectIndex - (P_Inven.X * P_Inven.Y);
        for (int i = 0; i < Player_ArrItem.Length; i++)
        {
            if (i != 0 && i % itemX == 0)
            {
                Console.WriteLine("");
            }

            if (SelectIdx_P == i)
            {
                Console.Write("▣");
            }
            else if (Player_ArrItem[i] == null)
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
        Console.WriteLine("소지금 : " + this.Gold + "G");
        Console.WriteLine("");
        if(selectedItem != null)
        {
            Console.WriteLine("선택한 아이템 : " + selectedItem.Name);
            Console.WriteLine("가격 : " + selectedItem.Gold + "G");
            Console.WriteLine("");
        }
        if (SelectIdx_P >= 0 && SelectIdx_P < Player_X * Player_Y)
        {
            if (Player_ArrItem[SelectIdx_P] == null)
            {
                Console.WriteLine("현재 선택된 슬롯");
                Console.WriteLine("비어있음");
            }
            else
            {
                Console.WriteLine("현재 선택된 슬롯");
                Console.WriteLine("이름 : " + Player_ArrItem[SelectIdx_P].Name);
                Console.WriteLine("가격 : " + Player_ArrItem[SelectIdx_P].Gold + "G");
            }
        }
    }

    public override bool OverCheck(int _SelectIndex)
    {
        //_SelectIndex = SelectIdx_P;
        if ((_SelectIndex >= Player_ArrItem.Length && _SelectIndex < (Player_ArrItem.Length*2)) && switchShopAndPlayer)
        {

            return false;
        }
        else
        {
            //switchShopAndPlayer = !switchShopAndPlayer;
            return true;
        }
    }

    public override void SelectMoveUp()
    {
        int CheckIdx = SelectIndex;
        CheckIdx -= itemX;

        if (OverCheck(CheckIdx)) switchShopAndPlayer = !switchShopAndPlayer;
        SelectIndex -= itemX;
    }

    public override void SelectMoveDown()
    {
        int CheckIdx = SelectIndex;
        CheckIdx += itemX;

        if (OverCheck(CheckIdx))
        {
            return;
            //switchShopAndPlayer = !switchShopAndPlayer;
        }
        SelectIndex += itemX;
    }

    public override void SelectMoveLeft()
    {
        int CheckIdx = SelectIndex;
        CheckIdx--;

        if (OverCheck(CheckIdx))
        {
            switchShopAndPlayer = !switchShopAndPlayer;
        }

        SelectIndex--;
    }

    public void SelectItem()
    {
        if (shopInven != null)
        {
            if (selectedItem == null) // 아이템 쥐기
            {
                if (SelectIndex >= 0 && SelectIndex < shopInven.Shop_ArrItem.Length) {
                    // 샵에 있는 아이템 쥐기 ? > 구매하고자 함
                    selectedItemNumber = SelectIndex;
                    To_Buy_Item = true;
                    selectedItem = shopInven.Shop_ArrItem[SelectIndex];
                    shopInven.Shop_ArrItem[SelectIndex] = null;
                }
                else if (SelectIndex >= Player_ArrItem.Length && SelectIndex < (Player_ArrItem.Length * 2))
                {
                    // 플레이어 인벤에서 아이템 쥐기 ? > 판매하고자 함
                    To_Sell_Item = true;
                    selectedItem = Player_ArrItem[SelectIdx_P];
                    Player_ArrItem[SelectIdx_P] = null;
                }
            }
            else // 아이템을 쥐었을 때
            {
                // 구매하거나 플레이어 인벤에서 위치를 단순히 바꾸고자 할 때
                if (SelectIndex >= Player_ArrItem.Length && SelectIndex < (Player_ArrItem.Length * 2)){
                    if (To_Buy_Item) // 구매하고자 할 때
                    {
                        if (selectedItem.Gold <= this.Gold)
                        {
                            this.Gold -= selectedItem.Gold;
                            Player_ArrItem[SelectIdx_P] = selectedItem;
                            selectedItem = null;
                            To_Buy_Item = false;
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("소지금이 부족합니다!");
                            shopInven.Shop_ArrItem[selectedItemNumber] = selectedItem;
                            selectedItem = null;
                            To_Buy_Item = false;
                            Console.ReadKey();
                            return;
                        }
                    }
                    else
                    {
                        Player_ArrItem[SelectIdx_P] = selectedItem;
                        selectedItem = null;
                        To_Sell_Item = false;
                    }
                    
                }
                // 판매하거나, 샵에서 아이템 위치를 바꾸고자 할 때
                else if (SelectIndex >= 0 && SelectIndex < shopInven.Shop_ArrItem.Length)
                {
                    if (To_Sell_Item) {
                        this.Gold += selectedItem.Gold;
                        shopInven.Shop_ArrItem[SelectIndex] = selectedItem;
                        selectedItem = null;
                        
                        To_Sell_Item = false;
                    }
                    else
                    {
                        shopInven.Shop_ArrItem[SelectIndex] = selectedItem;
                        selectedItem = null;
                        To_Buy_Item = false;
                    }                   
                }
            }
        }
    }
}

