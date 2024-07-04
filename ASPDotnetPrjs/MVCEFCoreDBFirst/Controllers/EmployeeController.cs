﻿using Microsoft.AspNetCore.Mvc;
using MVCEFCoreDBFirst.Models;

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
            var lstEmps = repo.GetEmps();
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
            repo.AddEmployee(emp);  
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            //delete the record by id using Repository            
            repo.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //find the record by id using repository
            var record=repo.GetEmpById(id);
            //display the view with record for edit
            return View(record);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            //update the record by id using repository
            repo.UpdateEmp(emp);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            //find the record by id using repository
            var record = repo.GetEmpById(id);
            //display the record in a detail view

            return View(record);
        }
    }
}