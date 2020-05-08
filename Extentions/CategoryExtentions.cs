using LightspeedNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightspeedNET.Extentions
{
    public static class CategoryExtentions
    {
        public static void Delete(this Category category) => Categories.DeleteCategory(category);
        public static void Update(this Category category) => Categories.UpdateCategory(category);

        public static Category Rename(this Category category, string name)
        {
            category.Name = name;
            return category;
        }
    }
}
