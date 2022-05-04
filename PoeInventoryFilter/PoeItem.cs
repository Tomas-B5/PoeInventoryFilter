using GameOverlay.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoeInventoryFilter
{
    enum  ItemRarity { Undefined, Normal, Magic, Rare, Unique, Other };
    enum ItemType { Undefined, Map, Flask, Weapon, Equipable, Jewel, Amulet, Ring, Belt };
    [Flags]
    enum Influence { None, Shaper, Elder, Hunter, Warlord, Redeemer, Warlorld};

    class drawline
    {
        string line;
        uint color = 0xFFFFFFFF;
    }
    struct InventoryGridSlot
    {
        int x;
        int y;
        public InventoryGridSlot(int screenX, int screenY, Point screenRes)
        {
            x = screenX;
            y = screenY;
        }
    }
    class PoeItem
    {
        //string cbdata;

        Influence influence1;
        Influence influence2;

        ItemRarity rarity;
        ItemType type;
        string name;
        string basename;

        double modweight;

        //For items in the inventory grid
        InventoryGridSlot slot;
        //For items that are not in inventory.
        Point ScreenLoc;

        List<drawline> modlines;

    }
}
