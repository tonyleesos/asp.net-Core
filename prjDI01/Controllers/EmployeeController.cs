using Microsoft.AspNetCore.Mvc;
using prjDI01.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace prjDI01.Controllers
{
    public class EmployeeController : Controller
    {
        private EmpDbContext _empDbContext;
        public EmployeeController(EmpDbContext context)
        {
            _empDbContext = context;
        }
        [Authorize(Roles = "member, admin")]
        public IActionResult Index()
        {
            var employees = _empDbContext.TEmployees.ToList();
            return View(employees);
        }
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TEmployee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _empDbContext.TEmployees.Add(employee);
                    _empDbContext.SaveChanges();
                    TempData["Success"] = "員工紀錄新增成功";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "員工編號重複";
                }
            }
            return View(employee);
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(string id)
        {
            var employee = _empDbContext.TEmployees.Find(id);
            _empDbContext.TEmployees.Remove(employee);
            _empDbContext.SaveChanges();
            TempData["Success"] = "員工紀錄刪除成功";
            return RedirectToAction("Index");
            
        }
        [Authorize(Roles = "admin")]
        public IActionResult Edit(string id)
        {
            var employee = _empDbContext.TEmployees.Find(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(TEmployee employeeData)
        {
            if (ModelState.IsValid)
            {
                try
                {                  
                    TEmployee employee = _empDbContext.TEmployees.Find(employeeData.FEmpId);
                    employee.FName = employeeData.FName;
                    employee.FGender = employeeData.FGender;
                    employee.FMail = employeeData.FMail;
                    employee.FSalary = employeeData.FSalary;
                    employee.FEmploymentDate = employeeData.FEmploymentDate;

                    _empDbContext.SaveChanges();
                    TempData["Success"] = "員工紀錄修改成功";

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "員工紀錄無法修改，請重新檢視修改紀錄";
                }
            }
            return View(employeeData);
        }

        // 會員登入
        public IActionResult Login()
        {           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string uid, string pwd)
        {
            var member = new MemberList().GetMember(uid, pwd);
            if(member != null)
            {
                // 建立身分宣告
                IList<Claim> claims = new List<Claim>{ 
                    new Claim(ClaimTypes.Name, member.Uid), 
                    new Claim(ClaimTypes.Role, member.Role) 
                };

                // 建立身分識別物件 指定帳號與角色
                var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties { IsPersistent = true };
                // 進行登入動作 帶入身分識別物件
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                return RedirectToAction("Index","Employee", member.Role);
            }
            else
            {
                ViewBag.Show = "帳密錯誤";
                return View();
            }
        }
        // 會員登出
        public IActionResult Lougout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
