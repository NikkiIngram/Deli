using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deli.DAL;
using Deli.Models;
using Deli.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Protocols;

namespace Deli.Controllers
{
    public class OrderController : Controller
    {

        private readonly DeliContext _context;
        private int _orderId;

        public OrderController(DeliContext context)
        {
            _context = context;

        }

        public IActionResult Index(User user= null)
        {

            var _order = new OrderForm()
            {
                ingredientTypes = _context.IngredientTypes.ToList(),
                itemTypes = _context.ItemTypes.ToList(),
                ingredients = _context.Ingredients.ToList(),
                LettuceOptions = _context.Ingredients.
                Where(x => x.IngredientTypeId == (_context.IngredientTypes.Where(y => y.IngredientTypeName == "Lettuce")).SingleOrDefault().IngredientTypeId).
                Select(u => new SelectListItem
                {
                    Text = u.IngredientName,
                    Value = u.IngredientTypeId.ToString()
                }).ToList(),
                BreadOptions = _context.Ingredients.
                        Where(x => x.IngredientTypeId == (_context.IngredientTypes.Where(y => y.IngredientTypeName == "Bread")).SingleOrDefault().IngredientTypeId).
                Select(u => new SelectListItem
                {
                    Text = u.IngredientName,
                    Value = u.IngredientTypeId.ToString()
                }).ToList(),
                SaladCheese = _context.Ingredients.
                    Where(x => x.IngredientTypeId == (_context.IngredientTypes.Where(y => y.IngredientTypeName == "Cheese")).SingleOrDefault().IngredientTypeId
                    & x.SaladIngredient == true).ToList(),
                SandwichCheese = _context.Ingredients.
                    Where(x => x.IngredientTypeId == (_context.IngredientTypes.Where(y => y.IngredientTypeName == "Cheese")).SingleOrDefault().IngredientTypeId
                    & x.SandwichIngredient == true).ToList(),
            Condiment = _context.Ingredients.
                    Where(x => x.IngredientTypeId == (_context.IngredientTypes.Where(y => y.IngredientTypeName == "Condiment")).SingleOrDefault().IngredientTypeId).ToList(),
                Dressings = _context.Ingredients.
                        Where(x => x.IngredientTypeId == (_context.IngredientTypes.Where(y => y.IngredientTypeName == "Dressing")).SingleOrDefault().IngredientTypeId).
                Select(u => new SelectListItem
                {
                    Text = u.IngredientName,
                    Value = u.IngredientTypeId.ToString()
                }).ToList(),
                SaladExtras = _context.Ingredients.
                    Where(x => x.IngredientTypeId == (_context.IngredientTypes.Where(y => y.IngredientTypeName == "Extras")).SingleOrDefault().IngredientTypeId
                    & x.SaladIngredient == true).ToList(),
            SandwichExtras = _context.Ingredients.
                Where(x => x.IngredientTypeId == (_context.IngredientTypes.Where(y => y.IngredientTypeName == "Extras")).SingleOrDefault().IngredientTypeId
                & x.SandwichIngredient == true).ToList(),
            SaladMeat = _context.Ingredients.
                Where(x => x.IngredientTypeId == (_context.IngredientTypes.Where(y => y.IngredientTypeName == "Meat")).SingleOrDefault().IngredientTypeId
                & x.SaladIngredient == true).ToList(),
                SandwichMeat = _context.Ingredients.
                    Where(x => x.IngredientTypeId == (_context.IngredientTypes.Where(y => y.IngredientTypeName == "Meat")).SingleOrDefault().IngredientTypeId
                    & x.SandwichIngredient == true).ToList(),
            SaladVeggies =_context.Ingredients.
                Where(x => x.IngredientTypeId == (_context.IngredientTypes.Where(y => y.IngredientTypeName == "Veggies")).SingleOrDefault().IngredientTypeId
                & x.SaladIngredient == true).ToList(),
            SandwichVeggies = _context.Ingredients.
                Where(x => x.IngredientTypeId == (_context.IngredientTypes.Where(y => y.IngredientTypeName == "Veggies")).SingleOrDefault().IngredientTypeId
                & x.SandwichIngredient == true).ToList(),
            
        };
            _order.user = user;
            var dbOrder = new Order() { UserId = user.UserId, OrderDate = DateTime.Now };
            _context.Orders.Add(dbOrder);
            _context.SaveChanges();

            _order.order = dbOrder;
            _orderId = dbOrder.OrderId;


            return View(_order);
        }

        public IActionResult AddSelectionToOrder(OrderForm _order)
        {
            if(_order.item.ItemType.ItemTypeName == "Salad")
            {
                Item item = new Item() { OrderId = _order.order.OrderId, ItemTypeId = 1};
                _context.Items.Add(item);
                _context.SaveChanges();
                _order.Lettuce = _order.Lettuce == "Select Your Lettuce" ? "29" : _order.Lettuce;
                _order.Dressing = _order.Dressing == "Select Your Dressing" ? "23" : _order.Dressing;

                List<Item_Ingredient> ingredients = new List<Item_Ingredient>()
                {
                    new Item_Ingredient(){ItemId = item.ItemId, IngredientId = Convert.ToInt32(_order.Lettuce) },
                    new Item_Ingredient(){ItemId = item.ItemId, IngredientId = Convert.ToInt32(_order.Dressing)},
                };
                    foreach(Ingredient meat in _order.SaladMeat.Where(x => x.Selected == true))
                {
                    ingredients.Add( new Item_Ingredient() { ItemId = item.ItemId, IngredientId = meat.IngredientId });
                }
                foreach (Ingredient veggie in _order.SaladVeggies.Where(x => x.Selected == true))
                {
                    ingredients.Add(new Item_Ingredient() { ItemId = item.ItemId, IngredientId = veggie.IngredientId });
                }
                foreach (Ingredient cheese in _order.SaladCheese.Where(x => x.Selected == true))
                {
                    ingredients.Add(new Item_Ingredient() { ItemId = item.ItemId, IngredientId = cheese.IngredientId });
                }
                foreach (Ingredient extra in _order.SaladExtras.Where(x => x.Selected == true))
                {
                    ingredients.Add(new Item_Ingredient() { ItemId = item.ItemId, IngredientId = extra.IngredientId });
                }
                foreach(Item_Ingredient ingredient in ingredients)
                {
                    _context.Item_Ingredients.Add(ingredient);
                }
                _context.SaveChanges();
            }
            else if(_order.item.ItemType.ItemTypeName == "Sandwich")
            {
                Item item = new Item() { OrderId = _order.order.OrderId, ItemTypeId = 2 };
                _context.Items.Add(item);
                _context.SaveChanges();

                _order.Bread = _order.Bread == "Select Your Bread" ? "3" : _order.Bread;

                List<Item_Ingredient> ingredients = new List<Item_Ingredient>()
                {
                    new Item_Ingredient(){ItemId = item.ItemId, IngredientId = Convert.ToInt32(_order.Bread) },
                };
                foreach (Ingredient meat in _order.SandwichMeat.Where(x => x.Selected == true))
                {
                    ingredients.Add(new Item_Ingredient() { ItemId = item.ItemId, IngredientId = meat.IngredientId });
                }
                foreach (Ingredient veggie in _order.SandwichVeggies.Where(x => x.Selected == true))
                {
                    ingredients.Add(new Item_Ingredient() { ItemId = item.ItemId, IngredientId = veggie.IngredientId });
                }
                foreach (Ingredient cheese in _order.SandwichCheese.Where(x => x.Selected == true))
                {
                    ingredients.Add(new Item_Ingredient() { ItemId = item.ItemId, IngredientId = cheese.IngredientId });
                }
                foreach (Ingredient extra in _order.Condiment.Where(x => x.Selected == true))
                {
                    ingredients.Add(new Item_Ingredient() { ItemId = item.ItemId, IngredientId = extra.IngredientId });
                }
                foreach (Item_Ingredient ingredient in ingredients)
                {
                    _context.Item_Ingredients.Add(ingredient);
                }
                _context.SaveChanges();

            }

            Console.Write("oh yea!");
            return RedirectToAction("CheckOut", _order);
        }

        public IActionResult CheckOut(OrderForm _order)
        {

            return View(_order);
        }

        //public IActionResult PlaceAddlOrder(OrderForm _order)
        //{
        //    return View("Index", _order);
        //}
    }
}