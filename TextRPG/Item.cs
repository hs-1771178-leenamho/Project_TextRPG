using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Item
{
    String mName;
    int mGold;

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

    public Item(string _Name, int _Gold)
    {
        this.Name = _Name;
        this.Gold = _Gold;
    }
}

