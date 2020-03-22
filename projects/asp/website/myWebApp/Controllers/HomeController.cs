using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Encodings.Web;
using myWebApp.Models;

namespace myWebApp.Controllers
{
    public class HomeController : Controller
    {
        // 
        // GET: /Test/

        public IActionResult Index()
        {
            User user = new User();
            user.Age = 10;
            user.FirstName = "Rhodes";
            user.LastName = "Skelton";
            user.Id = 1;
            user.Birthday = DateTime.Today;

            return View(user);
        }

        // 
        // GET: /Test/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}