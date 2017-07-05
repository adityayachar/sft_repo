using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleappVS.Controllers
{
    public class CompanyController : Controller
    {
        private TESTContext _context;
        public CompanyController(TESTContext context)
        {
            this._context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_context.Company.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Company cmpny)
        {
            if (ModelState.IsValid)
            {
                _context.Company.Add(cmpny);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cmpny);
        }
    }
}
