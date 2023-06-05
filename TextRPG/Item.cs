using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Item
{
    String mName;
    int mGold;
    int mItemAt;
    int mItemDef;

    public String Name
    {
        get
        {
            return mName;
        }
        set
        {
            this.mName = value;
        }
    }

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

    public int ItemAt
    {
        get
        {
            return mItemAt;
        }
        set
        {
            this.mItemAt = value;
        }
    }

    public int ItemDef
    {
        get
        {
            return mItemDef;
        }
        set
        {
            this.mItemDef = value;
        }
    }

    public Item(string _Name, int _Gold, int _ItemAt, int _ItemDef)
    {
        this.Name = _Name;
        this.Gold = _Gold;
        this.ItemAt = _ItemAt;
        this.ItemDef = _ItemDef;
    }
}

