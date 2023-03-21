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
        public IActionResult Index()
        {
            ViewBag.Msg = "User Doesnt exist";
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
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,res.Email),
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
                    return RedirectToAction("Employee/ViewAll");
            }
            //}
            return RedirectToAction("Index");
        }
    }
}
