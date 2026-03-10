using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMVC.Data;
using ProjectMVC.Models.Entities;

namespace ProjectMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _context;

        public StudentController(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? keyword)
        {
            var query = _context.Students.AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(student =>
                    student.StudentCode.Contains(keyword) ||
                    student.FullName.Contains(keyword));
            }

            ViewBag.Keyword = keyword;
            var listStudents = await query
                .OrderBy(student => student.StudentCode)
                .ToListAsync();

            return View(listStudents);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student std)
        {
            if (!ModelState.IsValid)
            {
                return View(std);
            }

            var studentExists = await _context.Students.AnyAsync(student => student.StudentCode == std.StudentCode);
            if (studentExists)
            {
                ModelState.AddModelError(nameof(Student.StudentCode), "Ma sinh vien da ton tai.");
                return View(std);
            }

            _context.Students.Add(std);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var std = await _context.Students.FindAsync(id);
            if (std == null)
            {
                return NotFound();
            }

            return View(std);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Student std)
        {
            if (id != std.StudentCode)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(std);
            }

            var studentExists = await _context.Students.AnyAsync(student => student.StudentCode == id);
            if (!studentExists)
            {
                return NotFound();
            }

            _context.Update(std);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var std = await _context.Students.AsNoTracking().FirstOrDefaultAsync(student => student.StudentCode == id);
            if (std == null)
            {
                return NotFound();
            }

            return View(std);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var std = await _context.Students.FindAsync(id);
            if (std == null)
            {
                return RedirectToAction(nameof(Index));
            }

            _context.Students.Remove(std);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}