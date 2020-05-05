using System;
using LightspeedNET.Models;

namespace LightspeedNET
{
    public static class ItemExtentions
    {
        public static void Update(this Item item)
        {
            Items.UpdateItem(item);
        }
    }
}
