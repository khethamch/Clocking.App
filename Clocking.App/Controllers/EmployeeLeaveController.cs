using Clocking.App.Models;
using Clocking.App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Clocking.App.Controllers
{


    public class EmployeeLeaveController : Controller
    {
        private readonly IEmployeeLeaveRepository _employeeLeaveRepository;

        public EmployeeLeaveController(IEmployeeLeaveRepository employeeLeaveRepository)
        {
            _employeeLeaveRepository = employeeLeaveRepository;
        }

        // GET: EmployeeLeave
        public async Task<ActionResult> Index()
        {

            var employeeLeave = await _employeeLeaveRepository.GetEmployeeLeaves();
            return View(employeeLeave);
        }

        //GET: EmployeeLeave/Details/
        public async Task<ActionResult> Details(int ID)
        {
            var employeeLeave = await _employeeLeaveRepository.GetEmployeeLeave(ID);
            if (employeeLeave == null) return HttpNotFound();
            return View(employeeLeave);
        }

        //GET: EmployeeLeave/Create
        public ActionResult Create()
        {
            return View();
        }

        //Post: EmployeeLeave/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(EmployeeLeave employeeLeave)
        {
            if (ModelState.IsValid)
            {
                await _employeeLeaveRepository.CreateEmployeeLeave(employeeLeave);
                return RedirectToAction("Index");
            }
            return View(employeeLeave);
        }

        //GET: EmployeeLeave/Edit/
        public async Task<ActionResult> Edit(int ID)
        {
            var employeeLeave = await _employeeLeaveRepository.GetEmployeeLeave(ID);
            if (employeeLeave == null) return HttpNotFound();
            return View(employeeLeave);
        }
        //POST: EmployeeLeave/Edit/ 
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit(EmployeeLeave employeeLeave)
        {
            if (ModelState.IsValid)
            {
                await _employeeLeaveRepository.UpdateEmployeeLeave(employeeLeave);
                return RedirectToAction("Index");
            }
            return View(employeeLeave);
        }

        // GET: Employees/Delete/
        public async Task<ActionResult> Delete(int id)
        {
            var employeeLeave = await _employeeLeaveRepository.GetEmployeeLeave(id);
            if (employeeLeave == null) return HttpNotFound();
            return View(employeeLeave);
        }

        // POST: EmployeeLeave/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _employeeLeaveRepository.DeleteEmployeeLeave(id);
            return RedirectToAction("Index");
        }
    }
}