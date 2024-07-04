using Microsoft.AspNetCore.Mvc;
using MVCHelloWorld.Models;

namespace MVCHelloWorld.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            var emp = new Employee
            {
                Ecode = 102,
                Ename = "Rahul",
                Salary = 2222,
                Deptid = 202
            };

            ViewData.Add("empObj", emp);

            return View();
        }
        public IActionResult Home()
        {
            var emp = new Employee
            {
                Ecode = 101,
                Ename = "Ravi",
                Salary=1111,
                Deptid=201
            };

            return View(emp);
        }

        public IActionResult DisplayEmps()
        {
            //var lstEmps = new List<Employee>
            //{
            //    new Employee{ Ecode=101,Ename="Ravi",Salary=1111,Deptid=201},
            //    new Employee{ Ecode=102,Ename="Rahul",Salary=2222,Deptid=202},
            //    new Employee{ Ecode=103,Ename="Rohit",Salary=3333,Deptid=203},
            //    new Employee{ Ecode=104,Ename="Raman",Salary=4444,Deptid=204},
            //    new Employee{ Ecode=105,Ename="Suresh",Salary=5555,Deptid=205}
            //};

            //1. get the record for deptid 201
            var dal = new LinqDataAccess();
            var lstEmps = dal.GetEmpsByDid(201);

            //2. order records by salary
            //lstEmps = dal.SortBySalary();

            //3. Group by and group functions
            //dal.GroupResult();

            //4. Joins
            //dal.JoinResult();

            return View(lstEmps);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            // Add data to Database
            ViewData.Add("msg", "Record inserted for employee :" + emp.Ecode);
            return View();
        }
    }
}
