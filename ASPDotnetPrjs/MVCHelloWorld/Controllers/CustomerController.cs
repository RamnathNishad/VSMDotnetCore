using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCHelloWorld.Models;

namespace MVCHelloWorld.Controllers
{
    public class CustomerController : Controller
    {
        List<SelectListItem> lstCities = new List<SelectListItem>();
        public CustomerController() 
        {
            lstCities = new List<SelectListItem>
            {
                new SelectListItem{Text="Bangalore",Value="BLR"},
                new SelectListItem{Text="Mysore",Value="MYS"},
                new SelectListItem{Text="Delhi",Value="DLI"},
                new SelectListItem{Text="Jaipur",Value="JPR"}
            };
        }
        public IActionResult Index()
        {
            ViewBag.Status = "Paid";

            ViewBag.record = new Employee
            {
                    Ecode=11111,
                    Ename="Ravi",
                    Salary=31323,
                    Deptid=201
            };

            ViewData.Add("cities", lstCities);
            return View("CustomerPageWK");
        }

        public IActionResult Home()
        {
            var customer = new Customer
            {
                Cities = lstCities,
                Hobbies =  new List<string> { "Biking", "Singing", "Painting" }
            };

            return View("CustomerPageST",customer);
        }



        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            //ViewData.Add("cities", lstCities);
            //ViewData.Add("data", customer);
            customer.Cities = lstCities;
            customer.SelectedHobbies=customer.Hobbies;

            customer.Hobbies = new List<string> { "Biking", "Singing", "Painting" };

            return View("CustomerPageST",customer);
        }
    }
}
