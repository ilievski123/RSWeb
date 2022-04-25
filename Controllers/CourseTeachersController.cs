#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RSWeb2022.Models;

namespace RSWeb2022.Controllers
{
    public class CourseTeachersController : Controller
    {
        private readonly RSWeb2022Context _context;

        public CourseTeachersController(RSWeb2022Context context)
        {
            _context = context;
        }

        // GET: CourseTeachers
        public async Task<IActionResult> Index()
        {
            var rSWeb2022Context = _context.CourseTeacher.Include(c => c.Course).Include(c => c.Teacher);
            return View(await rSWeb2022Context.ToListAsync());
        }

        // GET: CourseTeachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTeacher = await _context.CourseTeacher
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseTeacher == null)
            {
                return NotFound();
            }

            return View(courseTeacher);
        }

        // GET: CourseTeachers/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title");
            ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "Id", "FirstName");
            return View();
        }

        // POST: CourseTeachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeacherId,CourseId")] CourseTeacher courseTeacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseTeacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title", courseTeacher.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "Id", "FirstName", courseTeacher.TeacherId);
            return View(courseTeacher);
        }

        // GET: CourseTeachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTeacher = await _context.CourseTeacher.FindAsync(id);
            if (courseTeacher == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title", courseTeacher.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "Id", "FirstName", courseTeacher.TeacherId);
            return View(courseTeacher);
        }

        // POST: CourseTeachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeacherId,CourseId")] CourseTeacher courseTeacher)
        {
            if (id != courseTeacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseTeacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseTeacherExists(courseTeacher.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title", courseTeacher.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "Id", "FirstName", courseTeacher.TeacherId);
            return View(courseTeacher);
        }

        // GET: CourseTeachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTeacher = await _context.CourseTeacher
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseTeacher == null)
            {
                return NotFound();
            }

            return View(courseTeacher);
        }

        // POST: CourseTeachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseTeacher = await _context.CourseTeacher.FindAsync(id);
            _context.CourseTeacher.Remove(courseTeacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseTeacherExists(int id)
        {
            return _context.CourseTeacher.Any(e => e.Id == id);
        }
    }
}
