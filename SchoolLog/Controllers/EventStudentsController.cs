using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeGreat.Model;
using SchoolLog.Data;

namespace SchoolLog.Controllers
{
    public class EventStudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventStudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventStudents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EventStudents.Include(e => e.Event).Include(e => e.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EventStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventStudent = await _context.EventStudents
                .Include(e => e.Event)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (eventStudent == null)
            {
                return NotFound();
            }

            return View(eventStudent);
        }

        // GET: EventStudents/Create
       // public IActionResult Create()
       /// {
           // ViewData["EventId"] = new SelectList(_context.Events, "EventID", "EvenT");
          //  ViewData["EventId"] = new SelectList(_context.Students, "StudentID", "FirstName");
           // return View();
       // }

        // POST: EventStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,EventId")] EventStudent eventStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventID", "EventID", eventStudent.EventId);
            ViewData["EventId"] = new SelectList(_context.Students, "StudentID", "Address", eventStudent.EventId);
            return View(eventStudent);
        }

        // GET: EventStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventStudent = await _context.EventStudents.FindAsync(id);
            if (eventStudent == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventID", "EventID", eventStudent.EventId);
            ViewData["EventId"] = new SelectList(_context.Students, "StudentID", "Address", eventStudent.EventId);
            return View(eventStudent);
        }

        // POST: EventStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,EventId")] EventStudent eventStudent)
        {
            if (id != eventStudent.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventStudentExists(eventStudent.EventId))
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
            ViewData["EventId"] = new SelectList(_context.Events, "EventID", "EventID", eventStudent.EventId);
            ViewData["EventId"] = new SelectList(_context.Students, "StudentID", "Address", eventStudent.EventId);
            return View(eventStudent);
        }

        // GET: EventStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventStudent = await _context.EventStudents
                .Include(e => e.Event)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (eventStudent == null)
            {
                return NotFound();
            }

            return View(eventStudent);
        }

        // POST: EventStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventStudent = await _context.EventStudents.FindAsync(id);
            _context.EventStudents.Remove(eventStudent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventStudentExists(int id)
        {
            return _context.EventStudents.Any(e => e.EventId == id);
        }
    }
}
