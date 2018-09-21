using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deli.Models
{
    public class Item_Ingredient
    {
        public int Item_IngredientId { get; set; }
        public int ItemId { get; set; }
        public int IngredientId { get; set; }

        public virtual Item Item { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
