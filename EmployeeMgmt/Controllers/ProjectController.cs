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
    public class ProjectController : Controller
    {
        private IProjectsRepos pdb;
        private IEmployeeRepos emprepo;
        
        public ProjectController(IProjectsRepos _pdb,IEmployeeRepos employeeRepos)
        {
            pdb = _pdb;
            emprepo = employeeRepos;
           
        }
        public IActionResult ViewEmpProj()
        {
            var employeeprojects = pdb.ViewAll();
            return View(employeeprojects);
        }
        public ActionResult AddEmployeetoProj()
        {
            ViewBag.Empemail = new SelectList(emprepo.GetAll(), "Email", "Firstname");
            ViewBag.ProjId = new SelectList(pdb.ViewAllProjects(), "Projectid", "Projectname");
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployeetoProj(EmployeeProject empproj)
        {
            var emp = pdb.AddEmployee(empproj);
            return View(emp);
        }
    }
}