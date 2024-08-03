using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    /// <summary>
    /// Controladores para eliminar, agregar, actualizar o modificar usuarios
    /// </summary>
    public class EmployeeController : Controller
    {
        private static List<Employee> employees = new List<Employee>();

        public ActionResult Index()
        {
            return View("Index", "~/Views/Employees/Index.cshtml");
        }

        // Acion para agregar empleado
        [HttpGet]
        public JsonResult GetEmployees()
        {
            return Json(employees, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            employee.Id = employees.Count > 0 ? employees.Max(e => e.Id) + 1 : 1;
            employees.Add(employee);
            return Json(new { success = true });
        }

        // Acion para actualizar
        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            var existingEmployee = employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Position = employee.Position;
                existingEmployee.Office = employee.Office;
                existingEmployee.Salary = employee.Salary;
            }
            return Json(new { success = true });
        }

        // Acion para borrar
        [HttpPost]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
            }
            return Json(new { success = true });
        }
    }
}