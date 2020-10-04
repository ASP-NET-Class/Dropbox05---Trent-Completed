using System.Collections.Generic;
using System.Linq;
using Dropbox05.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dropbox05.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDbContext Db;
        public EmployeeController(EmployeeDbContext db)
        {
            this.Db = db;
        }
        public IActionResult AllEmployee()
        {
            return View(Db.Employees);
        }
        // GET: /<controller>/
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            Db.Add(employee);
            Db.SaveChanges();
            return RedirectToAction("AllEmployee");
        }
        public IActionResult EditEmployee(int id)
        {
            Employee employee;
            employee = Db.Employees.Find(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult DeleteEmployee(Employee employee)
        {
            Db.Remove(employee);
            Db.SaveChanges();
            return RedirectToAction("AllEmployee");
        }
    }
}