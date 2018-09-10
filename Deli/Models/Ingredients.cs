using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deli.Models
{
    public class Ingredient
    {
        public int IngredientId  { get; set; }
        public int ItemId { get; set; }
        public Ingredient_Enums IngredientType { get; set; }
        public  int _Ingredient { get; set; }
    }
}
