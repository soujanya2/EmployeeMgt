using EmployeeMgmt.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using EmployeeMgmt.Repository;

namespace EmployeeMgmt.Controllers
{
    public class LoginController : Controller
    {
        private IEmployeeRepos repodb;

        public LoginController(IEmployeeRepos _rdb)
        {
            repodb = _rdb;
        }
        public IActionResult Welcome()
        {
            return View();
        }
        public IActionResult Login(string returnurl)
        {
            ViewBag.ReturnUrl = returnurl;
            return View();
        }
        [HttpPost]
        public IActionResult Login(Employee emp)
        {
            var emplist = repodb.GetAll();
            var res = emplist.SingleOrDefault(x => x.Email.Equals(emp.Email));
            if (res != null && res.Password == emp.Password)
            {
                HttpContext.Session.SetString("Email", emp.Email);
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,res.Email),
                        new Claim(ClaimTypes.Role, res.Role)
                    };
                var claimsidentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(claimsidentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    IsPersistent = false,
                    //ExpiresUtc=DateTimeOffset.UtcNow.AddMinutes(10),
                    AllowRefresh = true
                }
                );
                if (HttpContext.Request.Query["ReturnUrl"].ToString() != "")
                    return Redirect(HttpContext.Request.Query["ReturnUrl"]);
                else
                    return RedirectToAction("ViewAll","Employee");
            }
            //}
            return RedirectToAction("Create","Employee");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult Details()
        {
            Employee Found = repodb.GetEmp(HttpContext.Session.GetString("Email"));
            return View(Found);
        }
    }
}
