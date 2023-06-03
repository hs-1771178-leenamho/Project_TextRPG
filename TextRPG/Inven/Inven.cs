using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 나는 아이템을 담아두는 인벤토리를 만들고 싶다.
// 인벤토리에 담을 수 있는 최대 아이템 갯수를 정해놓고 싶다.
// 이때 인벤토리의 가로 길이(x)와 세로 길이(y)가 필요하다.

// 나중에 싱글톤 적용해야하는 부분
class Inven
{
    public Item[] ArrItem;
    protected int itemX;
    public static int  SelectIndex = 0;
    protected static bool switchInvenMove = false;
    int mX;
    int mY;
    public int X
    {
        get
        {
            return this.mX;
        }
        set
        {
            this.mX = value;
        }
    }

    public int Y
    {
        get
        {
            return this.mY;
        }
        set
        {
            this.mY = value;
        }
    }
    public Inven(int _X, int _Y)
    {
        if (_X < 1)
        {
            _X = 1;
        }

        if (_Y < 1)
        {
            _Y = 1;
        }
        itemX = _X;
        this.X = _X;
        this.Y = _Y;
        ArrItem = new Item[_X * _Y];
    }

    public virtual bool OverCheck(int _SelectIndex)
    {
        if ((_SelectIndex >= 0 && _SelectIndex < ArrItem.Length))
        {
            //switchShopAndPlayer = !switchShopAndPlayer;
            return false;
        }
        else
        {
            
            return true;
        }
    }

    public int InvenSize()
    {
        return this.X * this.Y;
    }
    public void SelectMove(ConsoleKeyInfo CheckKey)
    {
        switch (CheckKey.Key)
        {
            case ConsoleKey.UpArrow:
                SelectMoveUp();
                break;
            case ConsoleKey.DownArrow:
                SelectMoveDown();
                break;
            case ConsoleKey.LeftArrow:
                SelectMoveLeft();
                break;
            case ConsoleKey.RightArrow:
                SelectMoveRight();
                break;
            default:
                break;
        }
    }

    public virtual void SelectMoveLeft()
    {
        int CheckIdx = SelectIndex;
        CheckIdx--;

        if (OverCheck(CheckIdx))
        {
            return;
        }

        SelectIndex--;
    }

    public virtual void SelectMoveRight()
    {
        int CheckIdx = SelectIndex;
        CheckIdx++;

        if (OverCheck(CheckIdx))
        {
            return;
        }

        SelectIndex++;
    }

    public virtual void SelectMoveUp()
    {
        int CheckIdx = SelectIndex;
        CheckIdx -= itemX;

        if (OverCheck(CheckIdx))
        {
            return;
        }

        SelectIndex -= itemX;
    }

    public virtual void SelectMoveDown()
    {
        int CheckIdx = SelectIndex;
        CheckIdx += itemX;

        if (OverCheck(CheckIdx))
        {
            return;
        }

        SelectIndex += itemX;

    }
    public virtual void Render()
    {
        for(int i = 0; i < ArrItem.Length; i++)
        {
            if(i != 0 && i % itemX == 0)
            {
                Console.WriteLine("");
            }

            if(SelectIndex == i)
            {
                Console.Write("▣");
            }
            else if(ArrItem[i] == null)
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
        if (ArrItem[SelectIndex] == null)
        {
            Console.WriteLine("현재 선택된 아이템");
            Console.WriteLine("비어있음");
        }
        else
        {
            Console.WriteLine("현재 선택된 아이템");
            Console.WriteLine("이름 : " + ArrItem[SelectIndex].Name);
            Console.WriteLine("가격 : " + ArrItem[SelectIndex].Gold);
        }
        

    }

    public virtual void ItemPut(Item _Item)
    {
        for(int i = 0; i < ArrItem.Length; i++)
        {
            if(ArrItem[i] == null)
            {
                ArrItem[i] = _Item;
                break;
            }
        }
    }

    public void ItemPut(Item _Item, int _Order)
    {
        if(_Order >= ArrItem.Length)
        {
            Console.WriteLine("잘못된 인벤토리 접근");
            Console.ReadKey();
            return;
        }

        if(ArrItem[_Order] != null)
        {
            Console.WriteLine("해당 위치에 아이템이 존재합니다.");
            Console.ReadKey();
            return;
        }
        
        ArrItem[_Order] = _Item;
        
    }
}

