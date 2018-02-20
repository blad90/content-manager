using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContentManager.Data;
using ContentManager.Models;

namespace ContentManager.Controllers
{
    public class StudyPlansController : Controller
    {
        private readonly CMContext _context;

        public StudyPlansController(CMContext context)
        {
            _context = context;
        }

        // GET: StudyPlans
        public async Task<IActionResult> Index()
        {
            var cMContext = _context.StudyPlans.Include(s => s.University);
            return View(await cMContext.ToListAsync());
        }

        // GET: StudyPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyPlan = await _context.StudyPlans
                .Include(s => s.University)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (studyPlan == null)
            {
                return NotFound();
            }

            return View(studyPlan);
        }

        // GET: StudyPlans/Create
        public IActionResult Create()
        {
            ViewData["UniversityID"] = new SelectList(_context.Universities, "ID", "ID");
            return View();
        }

        // POST: StudyPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Content,UniversityID")] StudyPlan studyPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studyPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UniversityID"] = new SelectList(_context.Universities, "ID", "ID", studyPlan.UniversityID);
            return View(studyPlan);
        }

        // GET: StudyPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyPlan = await _context.StudyPlans.SingleOrDefaultAsync(m => m.ID == id);
            if (studyPlan == null)
            {
                return NotFound();
            }
            ViewData["UniversityID"] = new SelectList(_context.Universities, "ID", "ID", studyPlan.UniversityID);
            return View(studyPlan);
        }

        // POST: StudyPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Content,UniversityID")] StudyPlan studyPlan)
        {
            if (id != studyPlan.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studyPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudyPlanExists(studyPlan.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UniversityID"] = new SelectList(_context.Universities, "ID", "ID", studyPlan.UniversityID);
            return View(studyPlan);
        }

        // GET: StudyPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyPlan = await _context.StudyPlans
                .Include(s => s.University)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (studyPlan == null)
            {
                return NotFound();
            }

            return View(studyPlan);
        }

        // POST: StudyPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studyPlan = await _context.StudyPlans.SingleOrDefaultAsync(m => m.ID == id);
            _context.StudyPlans.Remove(studyPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudyPlanExists(int id)
        {
            return _context.StudyPlans.Any(e => e.ID == id);
        }
    }
}
