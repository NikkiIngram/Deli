using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deli.Models
{
    public class Ingredient
    {
        public int IngredientId  { get; set; }
        public int IngredientTypeId { get; set; }
        public string IngredientName { get; set; }
        public bool SandwichIngredient { get; set; }
        public bool SaladIngredient { get; set; }
        public bool Selected { get; set; }

        public virtual IngredientType IngredientType{ get; set; }
    }
}
