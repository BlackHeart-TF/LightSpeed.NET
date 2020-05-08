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

        public static Item MoveCategory(this Item item, Category category)
        {
            item.Category = category;
            item.CategoryID = category.CategoryID;
            return item;
        }
    }
}
