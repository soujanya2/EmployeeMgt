﻿using EmployeeMgmt.Models;
using EmployeeMgmt.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeMgmt.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepos rdb;
        private EmployeeMgtContext db;
        public EmployeeController(IEmployeeRepos _rdb,EmployeeMgtContext _db)
        {
            rdb = _rdb;
            db= _db;
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            ViewData["deptid"] = new SelectList(db.Departments, "Deptid", "Deptname");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee entity)
        {
            if (rdb.AddEmployee(entity))
                return RedirectToAction("ViewAll");
            else
                return ViewBag.Msg("Employee Exist");
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Delete(string id)
        {
            if (rdb.DeleteEmployee(id))
            {
                return RedirectToAction("ViewAll");
            }
            return ViewBag.Msg("Employee Exist");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult ViewAll()
        {
        List<Employee> employees = rdb.GetAll();
        return View(employees);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(string id)
        {
            Employee ee = new Employee();
            ee=db.Employees.FirstOrDefault(x=>x.Email.Equals(id));
            var emp=rdb.GetEmployee(ee);
            //var emp=rdb.
            return View(emp);
        }
        [Authorize(Roles ="Employee")]
        public IActionResult EmpEdit(string id)     //create view dont forget
        {
            Employee ee = new Employee();
            ee = db.Employees.FirstOrDefault(x => x.Email.Equals(id));
            var emp = rdb.GetEmployee(ee);
            //var emp=rdb.
            return View(emp);
        }
        public IActionResult Update(Employee employee)
        {
            var emp=rdb.UpdateEmployee(employee);
            return RedirectToAction("ViewAll");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult SearchDept()
        {
            return View();
        }
        public IActionResult EmpListByDept(Department id)
        {
            List<Employee> employeelist = rdb.ListbyDept(id);
            return View(employeelist);
        }
        [Authorize(Roles ="Admin,Employee")]
        public IActionResult Search()
        {
            return View();
           // return View(rdb.GetEmployee(id));
        }
        [Authorize(Roles = "Admin,Employee")]
        public IActionResult Details(Employee id)
        {
            Employee Found = rdb.GetEmployee(id);
            return View(Found);  
        }
    }
}
