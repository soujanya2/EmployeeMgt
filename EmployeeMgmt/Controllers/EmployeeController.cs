using EmployeeMgmt.Models;
using EmployeeMgmt.Repository;
using Microsoft.AspNetCore.Mvc;

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
                return View();
            else
                return ViewBag.Msg("Employee Exist");
        }
        [HttpGet]
        //public IActionResult Delete(Employee entity) 
        //{

        //}
        public IActionResult View()
        {
            List<Employee> employees = rdb.GetAll();
            return View(employees); 
        }
        public IActionResult Edit(int id)
        {
            var emp=rdb.
            return View();
        }
        public IActionResult Update(Employee employee)
        {
            var emp=rdb.UpdateEmployee(employee);
            return View(emp);
        }
    }
}
