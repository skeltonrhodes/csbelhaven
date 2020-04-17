using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace myWebApp.Controllers
{
    public class TwoController : Controller
    {
        // 
        // GET: /Test/

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /Test/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}