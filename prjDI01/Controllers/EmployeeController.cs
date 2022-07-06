using Microsoft.AspNetCore.Mvc;
using prjDI01.Models;
namespace prjDI01.Controllers
{
    public class EmployeeController : Controller
    {
        private EmpDbContext _empDbContext;
        public EmployeeController(EmpDbContext context)
        {
            _empDbContext = context;
        }
        public IActionResult Index()
        {
            var employees = _empDbContext.TEmployees.ToList();
            return View(employees);
        }
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
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewData["Error"] = "員工編號重複";
                }
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var employee = _empDbContext.TEmployees.Find(id);
            _empDbContext.TEmployees.Remove(employee);
            _empDbContext.SaveChanges();
            return RedirectToAction("Index");
            
        }
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
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewData["Error"] = "員工紀錄無法修改，請重新檢視修改紀錄";
                }
            }
            return View(employeeData);
        }
    }
}
