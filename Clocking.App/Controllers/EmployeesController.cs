using Clocking.App.Models;
using Clocking.App.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Clocking.App.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesController(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        // GET: Employees
        public async Task<ActionResult> Index()
        {
            var employees = await _employeesRepository.GetEmployees();
            return View(employees);
        }

        // GET: Employees/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var employee = await _employeesRepository.GetEmployee(id);
            if (employee == null) return HttpNotFound();
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeesRepository.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var employee = await _employeesRepository.GetEmployee(id);
            if (employee == null) return HttpNotFound();
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeesRepository.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var employee = await _employeesRepository.GetEmployee(id);
            if (employee == null) return HttpNotFound();
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _employeesRepository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
