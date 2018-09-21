using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Deli.Models;
using Deli.DAL;

namespace Deli.Controllers
{
    public class HomeController : Controller
    {
        private readonly DeliContext _context;

        public HomeController(DeliContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View(new User());
        }

        public IActionResult LookUpMemberInfo(string userName, string password)
        {
         
            var result = _context.Users.SingleOrDefault(b => b.UserName == userName);
            if(result == null)
            {
                ViewBag.Message = String.Format("{0} is not a valid user name \\nPlease remeber user name is case sensitve", userName);
                return View("Index");
            }
            if(result.Password != password)
            {
                ViewBag.Message = String.Format("The password supplied is not correct \\nPlease remeber user name is case sensitve", userName);
                return View("Index");

            }

            return RedirectToAction("Index", "Order", result);
        }

        public IActionResult SubmitUserInfo(User user)
        {
            
            if(_context.Users.Any(b => b.UserName == user.UserName))
                {
                ViewBag.Message = String.Format("{0} is already taken." , user.UserName);
                return View("Index"); 
                }

            User dbUser = new User(user);
            _context.Users.Add(dbUser);
            _context.SaveChanges();

            return RedirectToAction("Index", "Order", dbUser);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
