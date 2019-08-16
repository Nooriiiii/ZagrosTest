
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZagrosTestProject;
using ZagrosTestProject.Entities;
using ZagrosTestProject.GenericRepository;

namespace ZagrosTestProject.Controllers
{
    [Authorize]
    public class EducationController : Controller
    {

        private IRepository<Education> _educationService;
        private IRepository<Personnel> _personnelService;
        private IRepository<EducationDegreeType> _educationDegreeService;

        public EducationController(IRepository<Education> educationService, IRepository<Personnel> personnelService,
            IRepository<EducationDegreeType> educationDegreeService)
        {
            _educationService = educationService;
            _personnelService = personnelService;
            _educationDegreeService = educationDegreeService;
        }

        // GET: Education
        public async Task<IActionResult> Index()
        {
            ViewData["PersonnelId"] = _personnelService.ListAllAsync();
            ViewData["EducationDegreeTypeId"] = _educationDegreeService.ListAllAsync();
            return View(await _educationService.ListAllAsync());
        }

        //// GET: Education/Details/5
        public async Task<IActionResult> Details(int id)
        {
            ViewData["PersonnelId"] = _personnelService.ListAllAsync();
            ViewData["EducationDegreeTypeId"] = _educationDegreeService.ListAllAsync();
            var education = await _educationService.GetByIdAsync(id);
            return View(education);
        }

        //// GET: Education/Create
        public async Task<IActionResult> Create()
        {
            var prs = (IEnumerable)await _personnelService.ListAllAsync();
            var mar = (IEnumerable)await _educationDegreeService.ListAllAsync();
            ViewData["PersonnelId"] = new SelectList(prs, "Id", "Id");
            ViewData["EducationDegreeTypeId"] = new SelectList(mar, "Id", "EducationDegreeDescription");
            return View();
        }

        // POST: Education/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonnelId,FromDate,ToDate,EducationDegreeTypeId")] Education education)
        {
            await _educationService.AddAsync(education);
            return RedirectToAction(nameof(Index));
        }

        // GET: Education/Edit/5
        public async Task<IActionResult> Edit(int id)

        {
            var prs = (IEnumerable)await _personnelService.ListAllAsync();
            var mar = (IEnumerable)await _educationDegreeService.ListAllAsync();
            ViewData["PersonnelId"] = new SelectList(prs, "Id", "Id");
            ViewData["EducationDegreeTypeId"] = new SelectList(mar, "Id", "EducationDegreeDescription");
            var education = await _educationService.GetByIdAsync(id);
            return View(education);
        }

        // POST: Education/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonnelId,FromDate,ToDate,EducationDegreeTypeId")] Education education)
        {
            await _educationService.UpdateAsync(education);
            return RedirectToAction(nameof(Index));
        }

        // GET: Education/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var prs = (IEnumerable)await _personnelService.ListAllAsync();
            var mar = (IEnumerable)await _educationDegreeService.ListAllAsync();
            ViewData["PersonnelId"] = new SelectList(prs, "Id", "Id");
            ViewData["EducationDegreeTypeId"] = new SelectList(mar, "Id", "EducationDegreeDescription");

            var education = await _educationService.GetByIdAsync(id);
            return View(education);
        }

        // POST: Education/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var education = await _educationService.GetByIdAsync(id);
            await _educationService.DeleteAsync(education);
            return RedirectToAction(nameof(Index));
        }
    }
}

