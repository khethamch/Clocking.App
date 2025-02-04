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
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // GET: Departments
        public async Task<ActionResult> Index()
        {
            var departments = await _departmentRepository.GetDepartments();
            return View(departments);
        }

        //GET: Department/Details/
        public async Task<ActionResult> Details(int ID)
        {
            var department = await _departmentRepository.GetDepartment(ID);
            if (department == null) return HttpNotFound();
            return View(department);
        }

        //GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create (Department department)
        {
            if (ModelState.IsValid)
            {
                await _departmentRepository.CreateDepartment(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        //GET: Departments/Edit
        public async Task<ActionResult> Edit(int ID)
        {
            var department = await _departmentRepository.GetDepartment(ID);
            if (department == null) return HttpNotFound();
            return View(department);
        }

        //GET: Departments/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                await _departmentRepository.UpdateDepartment(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        //GET: Departments/Delete?
        public async Task<ActionResult> Delete(int ID)
        {
            var department = await _departmentRepository.GetDepartment(ID);
            if (department == null) return HttpNotFound();
            return View(department);
        }

        //POST: Departments/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> DeleteConfirmed(int ID)
        {
            await _departmentRepository.DeleteDepartment(ID);
            return RedirectToAction("Index");
        }
    }
}