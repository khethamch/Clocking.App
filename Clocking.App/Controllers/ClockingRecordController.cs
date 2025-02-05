using Clocking.App.Models;
using Clocking.App.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Clocking.App.Controllers
{
    public class ClockingRecordController : Controller
    {
        private readonly IClockingRecordsRepository _clockingRecordsRepository;

        public ClockingRecordController(IClockingRecordsRepository clockingRecordsRepository)
        {
            _clockingRecordsRepository = clockingRecordsRepository;
        }

        // GET: Clocking Record
        public async Task<ActionResult> Index()
        {
            var records = await _clockingRecordsRepository.GetRecords();
            return View(records);
        }

        // GET: Record/Details
        public async Task<ActionResult> Details(int EmployeeID)
        {
            var record = await _clockingRecordsRepository.GetRecord(EmployeeID);
            if (record == null) return HttpNotFound();
            return View(record);
        }

        // GET: Clocking Records/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClockingRecord/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClockingRecord record)
        {
            if (ModelState.IsValid)
            {
                await _clockingRecordsRepository.CreateRecord(record);
                return RedirectToAction("Index");
            }
            return View(record);
        }

        // GET: Employees/Edit/5
        public async Task<ActionResult> Edit(int EmployeeID)
        {
            var record = await _clockingRecordsRepository.GetRecord(EmployeeID);
            if (record == null) return HttpNotFound();
            return View(record);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ClockingRecord record)
        {
            if (ModelState.IsValid)
            {
                await _clockingRecordsRepository.UpdateRecord(record);
                return RedirectToAction("Index");
            }
            return View(record);
        }

        // GET: Employees/Delete/5
        public async Task<ActionResult> Delete(int employeeID)
        {
            var record = await _clockingRecordsRepository.GetRecord(employeeID);
            if (record == null) return HttpNotFound();
            return View(record);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int employeeID)
        {
            await _clockingRecordsRepository.DeleteRecord(employeeID);
            return RedirectToAction("Index");
        }
    }
}