using Microsoft.AspNetCore.Mvc;
using MVCHelloWorld.Models;

namespace MVCHelloWorld.Controllers
{
    public class StateManagementController : Controller
    {
        public IActionResult Index()
        {
            //TempData.Add("x", 100);
            HttpContext.Session.SetInt32("y", 200);

            return View();
        }

        public IActionResult SecondPage()
        {
            var y=HttpContext.Session.GetInt32("y");
            ViewData.Add("y", y);
            return View();
        }

        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginPage(Login login)
        {
            //check whether credential is valid or not
            if (login.UserName != "admin" && login.Password != "abc")
            {
                //add model error 
                ModelState.AddModelError("UserName", "invalid username/password!!!");
            }


            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                //store the user name in the HttpCookie
                HttpContext.Response.Cookies.Append("uname", login.UserName);
                return RedirectToAction("Welcome");
            }
        }

        public IActionResult Welcome()
        {
            //read from the HttpCookie
            var uname = HttpContext.Request.Cookies["uname"];
            ViewData.Add("uname", uname);
            return View();
        }
    }
}
