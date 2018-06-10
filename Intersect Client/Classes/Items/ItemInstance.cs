﻿using System.ComponentModel.DataAnnotations.Schema;
using Intersect;
using Intersect.Enums;
using Intersect.GameObjects;

namespace Intersect_Client.Classes.Items
{
    public class ItemInstance
    {
        public int ItemNum = -1;
        public int ItemVal;
        public int[] StatBoost = new int[(int) Stats.StatCount];

        [NotMapped]
        public ItemBase Item => ItemBase.Lookup.Get<ItemBase>(ItemNum);

        public ItemInstance()
        {
        }

        public void Load(ByteBuffer bf)
        {
            ItemNum = bf.ReadInteger();
            ItemVal = bf.ReadInteger();
            for (int i = 0; i < (int) Stats.StatCount; i++)
            {
                StatBoost[i] = bf.ReadInteger();
            }
        }

        public ItemInstance Clone()
        {
            ItemInstance newItem = new ItemInstance()
            {
                ItemNum = ItemNum,
                ItemVal = ItemVal
            };
            for (int i = 0; i < (int) Stats.StatCount; i++)
            {
                newItem.StatBoost[i] = StatBoost[i];
            }
            return newItem;
        }
    }

    public class MapItemInstance : ItemInstance
    {
        public int X;
        public int Y;

        public MapItemInstance() : base()
        {
        }

        public void Load(ByteBuffer bf)
        {
            X = bf.ReadInteger();
            Y = bf.ReadInteger();
            base.Load(bf);
        }
    }
}