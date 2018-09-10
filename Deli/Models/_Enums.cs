using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deli.Models
{
    public class Ingredient_Enums
    {
        public int Id { get; set; }

        public enum Meat
        {
            Ham,
            Chicken,
            Turkey,
            RoastBeef,
            Salami,
            Pancetta,
            Prosuitto,
            Bacon,
            Pepperoni
        }

        public enum SandwichTopping
        {
            Peppers,
            Onions,
            Cucumbers,
            Tomatoes,
            Avocado,
            Cheese
        }

        public enum Lettuce
        {
            PowerGreens,
            Iceburg,
            Romaine,
            Butterhead
        }

        public enum SaladTopping
        {
            Peppers,
            Onions,
            Cucumbers,
            Tomatoes,
            Avocado,
            Croutons,
            Walnuts
        }

        public enum Dressing
        {
            Ranch,
            Itilian,
            AvocadoRanch,
            HoneyMustard,
            BlueCheese,
            French,
            Asian
        }

        public enum Bread
        {
            French,
            Wheat,
            Ciabatta,
            Rye,
            Flatbread,
            Sourdough
        }

        public enum Condiment
        {
            Mayo,
            AvocadoMayo,
            HoneyMustard,
            DijonMustard
        }
    }
    public class _Enums
    {
        public enum PaymentType
        {
            Cash,
            CreditCard
        }

        public enum CardType
        {
            Visa,
            MasterCard,
            Discover,
            AmericanExpres
        }

        public enum ItemType
        {
            Sandwich,
            Salad
        }
    }
}
