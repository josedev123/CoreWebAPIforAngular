using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebAPIforAngular.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebAPIforAngular.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext context;

        public EmployeeController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: Employee
        public ActionResult Index()
        {
            var employees = context.Employees.ToList();

            return Json(employees);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var employee = context.Employees.SingleOrDefault(e => e.Id == id);

            return Json(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return Ok();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create([FromBody] Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();

            int eId = employee.Id;

            return Ok(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employeeInDb = context.Employees.SingleOrDefault(e => e.Id == id);

            return Ok(employeeInDb);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit([FromBody] Employee employee)
        {
            Employee employeeInDb = context.Employees.SingleOrDefault(e => e.Id == employee.Id);
            employeeInDb.Name = employee.Name;
            employeeInDb.Email = employee.Email;

            context.SaveChanges();

            return Ok(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}