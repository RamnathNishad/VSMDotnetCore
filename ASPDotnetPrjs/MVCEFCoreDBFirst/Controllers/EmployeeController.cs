using Microsoft.AspNetCore.Mvc;
using MVCEFCoreDBFirst.Models;
using System.Text.Json;

namespace MVCEFCoreDBFirst.Controllers
{
    public class EmployeeController : Controller
    {
        //inject the Repository object into constructor

        readonly IEmployeeRepository repo;
        public EmployeeController(IEmployeeRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            //var lstEmps = repo.GetEmps();
            var lstEmps=ApiConsumer.GetEmps();
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
            //using Repository insert the record in Database
            //repo.AddEmployee(emp);  
            
            var status=ApiConsumer.AddEmployee(emp);
            if (status)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            //delete the record by id using Repository            
            //repo.DeleteEmployee(id);
            ApiConsumer.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //find the record by id using repository
            //var record=repo.GetEmpById(id);

            var record=ApiConsumer.GetEmpById(id);
            //display the view with record for edit
            return View(record);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            //update the record by id using repository
            //repo.UpdateEmp(emp);

            ApiConsumer.UpdateEmployee(emp);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            //find the record by id using repository
            //var record = repo.GetEmpById(id);

            var record = ApiConsumer.GetEmpById(id);
            //display the record in a detail view

            return View(record);
        }

        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginPage(Users user)
        {
            var baseUrl = "http://localhost:5024/api/Employee/";
            //get the token from web api using credentials
            using (var http =new HttpClient())
            {
                http.BaseAddress = new Uri(baseUrl);
                var response = http.PostAsJsonAsync("authenticate", user);
                response.Wait();

                var responseResult=response.Result;
                if(responseResult.IsSuccessStatusCode)
                {
                    var token=responseResult.Content.ReadAsStringAsync();
                    token.Wait();
                    var tokenStr = token.Result;

                    //use the token to call the api methods
                    if (tokenStr != null)                    
                    {
                        using (var http2=new HttpClient())
                        {
                            http2.BaseAddress = new Uri(baseUrl);
                            //configure the request header for jwt bearer token
                            http2.DefaultRequestHeaders.Add("Authorization","Bearer "+tokenStr);

                            var resp2 = http2.GetAsync("GetAllEmps");
                            resp2.Wait();
                            var resp2Result=resp2.Result;

                            if (resp2Result.IsSuccessStatusCode)
                            {
                                //read the content of the response
                                var res2Data=resp2Result.Content.ReadAsStringAsync(); 
                                res2Data.Wait();

                                var finalData=res2Data.Result;

                                var lstEmps = JsonSerializer.Deserialize<List<Employee>>(finalData);

                                return View("Index", lstEmps);
                            }
                            else
                            {
                                return View();
                            }
                        }
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            };
        }
    }
}
