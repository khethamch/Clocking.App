using Clocking.App.Models;
using Clocking.App.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Clocking.App.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        // GET: Companies
        public async Task<ActionResult> Index()
        {
            var companies = await _companyRepository.GetCompanies();
            return View(companies);
        }

        // GET: Companies/Details/5
        public async Task<ActionResult> Details(int employeeID)
        {
            var company = await _companyRepository.GetCompany(employeeID);
            if (company == null) return HttpNotFound();
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Company company)
        {
            if (ModelState.IsValid)
            {
                await _companyRepository.CreateCompany(company);
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<ActionResult> Edit(int employeeID)
        {
            var company = await _companyRepository.GetCompany(employeeID);
            if (company == null) return HttpNotFound();
            return View(company);
        }

        // POST: Companies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                await _companyRepository.UpdateCompany(company);
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<ActionResult> Delete(int employeeID)
        {
            var company = await _companyRepository.GetCompany(employeeID);
            if (company == null) return HttpNotFound();
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int employeeID)
        {
            await _companyRepository.DeleteCompany(employeeID);
            return RedirectToAction("Index");
        }
    }
}