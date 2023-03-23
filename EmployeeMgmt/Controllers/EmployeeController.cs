using EmployeeMgmt.Models;
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
                return RedirectToAction("View");
            else
                return ViewBag.Msg("Employee Exist");
        }
        [Authorize("Admin")]
        public IActionResult Delete(string id)
        {
            if (rdb.DeleteEmployee(id))
            {
                return View();
            }
            return ViewBag.Msg("Employee Exist");
        }
        public IActionResult ViewAll()
        {
            List<Employee> employees = rdb.GetAll();
            return View(employees);
        }
        public IActionResult Edit(string id)
        {
            Employee ee = new Employee();
            ee=db.Employees.FirstOrDefault(x=>x.Email.Equals(id));
            var emp=rdb.GetEmployee(ee);
            //var emp=rdb.
            return View(emp);
        }
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
            return View(emp);
        }
        public IActionResult EmpListByDept(int id)
        {
            List<Employee> employeelist = rdb.ListbyDept(id);
            return View(employeelist);
        }
    }
}
