using EmployeeMgmt.Models;
using EmployeeMgmt.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeMgmt.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepos rdb;

        public EmployeeController(IEmployeeRepos _rdb)
        {
            rdb = _rdb;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee entity)
        {
            if (rdb.AddEmployee(entity))
                return RedirectToAction("View");
            bool i=rdb.AddEmployee(entity);
            if (i==true)
                return View();
            else
                return ViewBag.Msg("Employee Exist");
        }
        public IActionResult Delete(int id)
        {
            if (rdb.DeleteEmployee(id))
            {
                return View();
            }
            else
            {
                return ViewBag.Msg("Employee Not deleted");
            }

        }
        public IActionResult ViewAll()
        {
        List<Employee> employees = rdb.GetAll();
        return View(employees);
        }
        public IActionResult Edit(int id)
        {
            //var emp=rdb.
            return View();
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
       
        public IActionResult Search()
        {
            return View();
           // return View(rdb.GetEmployee(id));
        }
   
        public IActionResult Details(Employee id)
        {
            Employee Found = rdb.GetEmployee(id);
            return View(Found);
            
        }
    }
}
