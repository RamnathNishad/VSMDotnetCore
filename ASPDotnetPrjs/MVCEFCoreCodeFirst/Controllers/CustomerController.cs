using Microsoft.AspNetCore.Mvc;
using MVCEFCoreCodeFirst.Models;

namespace MVCEFCoreCodeFirst.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDBContext dbCtx;
        public CustomerController(CustomerDBContext dbCtx)
        {
            this.dbCtx = dbCtx;
        }

        public IActionResult Index()
        {           

            var lstCustomers=dbCtx.tbl_customer.ToList();

            return View(lstCustomers);
        }
    }
}
