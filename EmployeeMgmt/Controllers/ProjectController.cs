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
        private EmployeeProject db;
        public ProjectController(IProjectsRepos _pdb, EmployeeProject _db)
        {
            pdb = _pdb;
            db = _db;
        }
        public IActionResult ViewEmpProj()
        {
            var employeeprojects = pdb.ViewAll();
            return View(employeeprojects);
        }
        public ActionResult AddEmployeetoProj()
        {
            ViewData["emp"] = new SelectList((System.Collections.IEnumerable)db.EmpemailNavigation, "empemail", "Firstname");
            ViewData["proj"] = new SelectList((System.Collections.IEnumerable)db.Proj, "proj_id", "projectname");
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