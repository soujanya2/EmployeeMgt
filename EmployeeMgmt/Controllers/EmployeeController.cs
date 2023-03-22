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
            bool i=rdb.AddEmployee(entity);
            if (i==true)
                return View();
            else
                return ViewBag.Msg("Employee Exist");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            bool d = rdb.DeleteEmployee(id);
            if (d == true)
                return View();
            return View();
        }
        public IActionResult ViewAll()
        {
        List<Employee> employees = rdb.GetAll();
        return View(employees);
        }
       
        public IActionResult Search()
        {
            return View();
           // return View(rdb.GetEmployee(id));
        }
   
        public IActionResult Details(int employeeid)
        {
            Employee Found = rdb.GetEmployee(employeeid);
            return View(Found);
            
        }
    }
}
