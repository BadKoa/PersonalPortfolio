using firsttrywebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace firsttrywebsite.Controllers
{
    public class HomeController : Controller
    {
        [ResponseCache(Location = ResponseCacheLocation.None, Duration = 0, NoStore = true)]

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetMails(string name, string email)
        {
            var user = new User { Name = name, Email = email };

            using(var context = new UserContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
            //mails.Name?.ToString();
            //return View();
        }
    }
}
