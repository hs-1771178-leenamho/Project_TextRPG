using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PlayerInven : Inven
{
    Inven P_Inven;
    Item[] mPlayer_ArrItem;
    public Item[] Player_ArrItem
    {
        get
        {
            return this.mPlayer_ArrItem;
        }
        set
        {
            this.mPlayer_ArrItem = value;
        }
    }
    Item selectedItem;
    ShopInven mshopInven;
    protected ShopInven shopInven
    {
        get
        {
            return this.mshopInven;
        }
        set
        {
            this.mshopInven = value;
        }
    }
    PlayerEquipment mPlayerEquipment;
    protected PlayerEquipment playerEquipment
    {
        get
        {
            return this.mPlayerEquipment;
        }
        set
        {
            this.mPlayerEquipment = value;
        }
    }

    int SelectIdx_P;
    int mPlayer_X;
    public int Player_X
    {
        get
        {
            return mPlayer_X;
        }
    }
    int mPlayer_Y;
    public int Player_Y
    {
        get
        {
            return mPlayer_Y;
        }
    }
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
    bool To_Buy_Item = false; // 샵에서 아이템 구매를 위한 bool
    bool To_Sell_Item = false; // 샵에 아이템 판매를 위한 bool
    bool To_TakeOff_Item = false; // 장비를 벗기 위한 bool
    bool To_PutOn_Item = false; // 장비를 입기 위한 bool

    int selectedItemNumber = -1;

    public void SetShopInven(ShopInven S_Inven)
    {
        this.shopInven = S_Inven;
    }

    public void SetPlayerEquipment(PlayerEquipment P_Equip)
    {
        this.playerEquipment = P_Equip;
    }

    public PlayerInven(Inven _P_Inven) : base(_P_Inven.X, _P_Inven.Y)
    {
        this.P_Inven = _P_Inven;
        this.mPlayer_ArrItem = _P_Inven.ArrItem;
        this.SelectIdx_P = Inven.SelectIndex - (_P_Inven.X * _P_Inven.Y);
        this.mPlayer_X = _P_Inven.X;
        this.mPlayer_Y = _P_Inven.Y;
    }

    #region ActionBetweenShopAndPlayer

    public override void Render()
    {
        this.SelectIdx_P = Inven.SelectIndex - (P_Inven.X * P_Inven.Y);
        for (int i = 0; i < mPlayer_ArrItem.Length; i++)
        {
            if (i != 0 && i % itemX == 0)
            {
                Console.WriteLine("");
            }

            if (SelectIdx_P == i)
            {
                Console.Write("▣");
            }
            else if (mPlayer_ArrItem[i] == null)
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
        if (selectedItem != null)
        {
            Console.WriteLine("선택한 아이템 : " + selectedItem.Name);
            Console.WriteLine("가격 : " + selectedItem.Gold + "G");
            Console.WriteLine("");
        }
        if (SelectIdx_P >= 0 && SelectIdx_P < mPlayer_X * mPlayer_Y)
        {
            if (mPlayer_ArrItem[SelectIdx_P] == null)
            {
                Console.WriteLine("현재 선택된 슬롯");
                Console.WriteLine("비어있음");
            }
            else
            {
                Console.WriteLine("현재 선택된 슬롯");
                Console.WriteLine("이름 : " + mPlayer_ArrItem[SelectIdx_P].Name);
                Console.WriteLine("가격 : " + mPlayer_ArrItem[SelectIdx_P].Gold + "G");
            }
        }
    }
    public override bool OverCheck(int _SelectIndex)
    {
        if (this.shopInven == null) return true;
        else
        {
            //_SelectIndex = SelectIdx_P;
            if ((_SelectIndex >= mPlayer_ArrItem.Length && _SelectIndex < (mPlayer_ArrItem.Length * 2)) && shopInven.switchShopMove)
            {

                return false;
            }
            else
            {
                //switchShopAndPlayer = !switchShopAndPlayer;
                return true;
            }
        }
    }

    public override void SelectMoveUp()
    {
        int CheckIdx = SelectIndex;
        CheckIdx -= itemX;

        if (OverCheck(CheckIdx) && shopInven != null)
        {
            //return;
            shopInven.switchShopMove = !shopInven.switchShopMove;
        }
        SelectIndex -= itemX;
    }

    public override void SelectMoveDown()
    {
        int CheckIdx = SelectIndex;
        CheckIdx += itemX;

        if (OverCheck(CheckIdx) && shopInven != null)
        {
            //return;
            //shopInven.switchShopMove = !shopInven.switchShopMove;
            return;
        }
        SelectIndex += itemX;
    }

    public override void SelectMoveLeft()
    {
        int CheckIdx = SelectIndex;
        CheckIdx--;

        if (OverCheck(CheckIdx) && shopInven != null)
        {
            shopInven.switchShopMove = !shopInven.switchShopMove;
            //return;
        }

        SelectIndex--;
    }

    public override void SelectMoveRight()
    {
        int CheckIdx = SelectIndex;
        CheckIdx++;

        if (OverCheck(CheckIdx) && shopInven != null)
        {
            //return;
            //shopInven.switchShopMove = !shopInven.switchShopMove;
            return;
        }

        SelectIndex++;
    }

    public void SelectShopItem()
    {
        if (shopInven != null)
        {
            if (selectedItem == null) // 아이템 쥐기
            {
                if (SelectIndex >= 0 && SelectIndex < shopInven.Shop_ArrItem.Length)
                {
                    // 샵에 있는 아이템 쥐기 ? > 구매하고자 함
                    selectedItemNumber = SelectIndex;
                    To_Buy_Item = true;
                    selectedItem = shopInven.Shop_ArrItem[SelectIndex];
                    shopInven.Shop_ArrItem[SelectIndex] = null;
                }
                else if (SelectIndex >= mPlayer_ArrItem.Length && SelectIndex < (mPlayer_ArrItem.Length * 2))
                {
                    // 플레이어 인벤에서 아이템 쥐기 ? > 판매하고자 함
                    To_Sell_Item = true;
                    selectedItem = mPlayer_ArrItem[SelectIdx_P];
                    mPlayer_ArrItem[SelectIdx_P] = null;
                }
            }
            else // 아이템을 쥐었을 때
            {
                // 구매하거나 플레이어 인벤에서 위치를 단순히 바꾸고자 할 때
                if (SelectIndex >= mPlayer_ArrItem.Length && SelectIndex < (mPlayer_ArrItem.Length * 2))
                {
                    if (To_Buy_Item) // 구매하고자 할 때
                    {
                        if (selectedItem.Gold <= this.Gold)
                        {
                            this.Gold -= selectedItem.Gold;
                            mPlayer_ArrItem[SelectIdx_P] = selectedItem;
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
                        mPlayer_ArrItem[SelectIdx_P] = selectedItem;
                        selectedItem = null;
                        To_Sell_Item = false;
                    }

                }
                // 판매하거나, 샵에서 아이템 위치를 바꾸고자 할 때
                else if (SelectIndex >= 0 && SelectIndex < shopInven.Shop_ArrItem.Length)
                {
                    if (To_Sell_Item)
                    {
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
    #endregion

    #region ActionBetweenEqipAndPlayer

    public void RenderForE()
    {
        if (playerEquipment != null) this.SelectIdx_P = Inven.SelectIndex - playerEquipment.InvenSize();
        for (int i = 0; i < mPlayer_ArrItem.Length; i++)
        {
            if (i != 0 && i % itemX == 0)
            {
                Console.WriteLine("");
            }

            if (SelectIdx_P == i)
            {
                Console.Write("▣");
            }
            else if (mPlayer_ArrItem[i] == null)
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

        if (selectedItem != null)
        {
            Console.WriteLine("선택한 아이템 : " + selectedItem.Name);
            Console.WriteLine("");
        }
        if (SelectIdx_P >= 0 && SelectIdx_P < mPlayer_X * mPlayer_Y)
        {
            if (mPlayer_ArrItem[SelectIdx_P] == null)
            {
                Console.WriteLine("현재 선택된 슬롯");
                Console.WriteLine("비어있음");
            }
            else
            {
                Console.WriteLine("현재 선택된 슬롯");
                Console.WriteLine("이름 : " + mPlayer_ArrItem[SelectIdx_P].Name);
            }
        }
    }
    public void SelectMoveInEquip(ConsoleKeyInfo CheckKey)
    {
        switch (CheckKey.Key)
        {
            case ConsoleKey.UpArrow:
                SelectMoveUpInEquip();
                break;
            case ConsoleKey.DownArrow:
                SelectMoveDownInEquip();
                break;
            case ConsoleKey.LeftArrow:
                SelectMoveLeftInEquip();
                break;
            case ConsoleKey.RightArrow:
                SelectMoveRightInEquip();
                break;
            default:
                break;
        }
    }
    public bool OverCheckInEquip(int _SelectIndex)
    {
        int length = 0;
        if (playerEquipment != null)
        {
            length = playerEquipment.InvenSize();
        }
        else
        {
            return true;
        }

        if ((_SelectIndex >= length && _SelectIndex < length + this.InvenSize()) && playerEquipment.switchEquipMove)
        {

            return false;
        }
        else
        {
            //switchShopAndPlayer = !switchShopAndPlayer;
            return true;
        }
    }

    public void SelectMoveUpInEquip()
    {
        int CheckIdx = SelectIndex;
        CheckIdx -= itemX;

        if (OverCheckInEquip(CheckIdx) && playerEquipment != null)
        {
            //return;
            playerEquipment.switchEquipMove = !playerEquipment.switchEquipMove;
        }
        SelectIndex -= itemX;
    }

    public void SelectMoveDownInEquip()
    {
        int CheckIdx = SelectIndex;
        CheckIdx += itemX;

        if (OverCheckInEquip(CheckIdx) && playerEquipment != null)
        {
            //return;
            //switchInvenMove = !switchInvenMove;
            return;
        }
        SelectIndex += itemX;
    }

    public void SelectMoveLeftInEquip()
    {
        int CheckIdx = SelectIndex;
        CheckIdx--;

        if (OverCheckInEquip(CheckIdx) && playerEquipment != null)
        {
            playerEquipment.switchEquipMove = !playerEquipment.switchEquipMove;
            //return;
        }

        SelectIndex--;
    }

    public void SelectMoveRightInEquip()
    {
        int CheckIdx = SelectIndex;
        CheckIdx++;

        if (OverCheckInEquip(CheckIdx) && playerEquipment != null)
        {
            //return;
            //switchInvenMove = !switchInvenMove;
            return;
        }

        SelectIndex++;
    }

    public void SelectEquipItem()
    {
        if (playerEquipment != null)
        {
            if (selectedItem == null) // 아이템 쥐기
            {
                if (SelectIndex >= 0 && SelectIndex < playerEquipment.Equip_Arr.Length)
                {
                    // 장비창에서 아이템을 쥔다 ? 아이템 착용 해제
                    selectedItemNumber = SelectIndex;
                    To_TakeOff_Item = true;
                    selectedItem = playerEquipment.Equip_Arr[SelectIndex];
                    playerEquipment.Equip_Arr[SelectIndex] = null;
                }
                else if (SelectIndex >= playerEquipment.Equip_Arr.Length &&
                    SelectIndex < playerEquipment.Equip_Arr.Length + this.InvenSize())
                {
                    // 플레이어 인벤에서 아이템 쥐기 ? > 장비를 착용하고자 함
                    To_PutOn_Item = true;
                    selectedItem = mPlayer_ArrItem[SelectIdx_P];
                    mPlayer_ArrItem[SelectIdx_P] = null;
                }
            }
            else // 아이템을 쥐었을 때
            {
                // 벗거나 플레이어 인벤에서 위치를 단순히 바꾸고자 할 때
                if (SelectIndex >= playerEquipment.Equip_Arr.Length &&
                    SelectIndex < playerEquipment.Equip_Arr.Length + this.InvenSize())
                {
                    if (To_TakeOff_Item) // 벗고자 할 때
                    {
                        mPlayer_ArrItem[SelectIdx_P] = selectedItem;
                        selectedItem = null;
                        To_TakeOff_Item = false;

                    }
                    else
                    {
                        mPlayer_ArrItem[SelectIdx_P] = selectedItem;
                        selectedItem = null;
                        To_PutOn_Item = false;
                    }

                }
                // 착용하거나, 장비창에서 아이템 위치를 바꾸고자 할 때
                else if (SelectIndex >= 0 && SelectIndex < playerEquipment.Equip_Arr.Length)
                {
                    if (To_PutOn_Item)
                    {
                        playerEquipment.Equip_Arr[SelectIndex] = selectedItem;
                        selectedItem = null;

                        To_PutOn_Item = false;
                    }
                    else
                    {
                        playerEquipment.Equip_Arr[SelectIndex] = selectedItem;
                        selectedItem = null;
                        To_TakeOff_Item = false;
                    }


                }
            }
        }
    }
    #endregion
}

