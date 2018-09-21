using Deli.DAL;
using Deli.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deli.ViewModels
{
    public class OrderForm
    {
        public OrderForm()
        {
        }
        public List<IngredientType> ingredientTypes { get; set; }
        public List<ItemType> itemTypes { get; set; }
        public List<Ingredient> ingredients { get; set; }
        public List<SelectListItem> LettuceOptions { get; set; }
        public List<SelectListItem> BreadOptions { get; set; }
        public List<Ingredient> SaladCheese { get; set; }
        public List<Ingredient> SandwichCheese { get; set; }
        public List<Ingredient> Condiment { get; set; }
        public List<SelectListItem> Dressings { get; set; }
        public List<Ingredient> SaladExtras { get; set; }
        public List<Ingredient> SandwichExtras { get; set; }
        public List<Ingredient> SaladMeat { get; set; }
        public List<Ingredient> SandwichMeat { get; set; }
        public List<Ingredient> SaladVeggies { get; set; }
        public List<Ingredient> SandwichVeggies { get; set; }
        public User user { get; set; }
        public Order order { get; set; }
        public Item item { get; set; }
        public string Lettuce { get; set; }
        public string Dressing { get; set; }
        public string Bread { get; set; }
    }
}
