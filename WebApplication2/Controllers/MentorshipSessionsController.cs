using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MentorshipSessionsController : Controller
    {
        private readonly WebApplication2Context _context;

        public MentorshipSessionsController(WebApplication2Context context)
        {
            _context = context;
        }

        // GET: MentorshipSessions
        public async Task<IActionResult> Index()
        {
            var webApplication2Context = _context.MentorshipSession.Include(m => m.Mentor).Include(m => m.Student);
            return View(await webApplication2Context.ToListAsync());
        }

        // GET: MentorshipSessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentorshipSession = await _context.MentorshipSession
                .Include(m => m.Mentor)
                .Include(m => m.Student)
                .FirstOrDefaultAsync(m => m.MentorshipSessionId == id);
            if (mentorshipSession == null)
            {
                return NotFound();
            }

            return View(mentorshipSession);
        }

        // GET: MentorshipSessions/Create
        public IActionResult Create()
        {
            ViewData["MentorId"] = new SelectList(_context.Mentor, "MentorId", "MentorId");
            ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "StudentId", "StudentId");
            return View();
        }

        // POST: MentorshipSessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MentorshipSessionId,Date,Notes,StudentId,MentorId")] MentorshipSession mentorshipSession)
        {
            
                _context.Add(mentorshipSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["MentorId"] = new SelectList(_context.Mentor, "MentorId", "MentorId", mentorshipSession.MentorId);
            ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "StudentId", "StudentId", mentorshipSession.StudentId);
            
        }

        // GET: MentorshipSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentorshipSession = await _context.MentorshipSession.FindAsync(id);
            if (mentorshipSession == null)
            {
                return NotFound();
            }
            ViewData["MentorId"] = new SelectList(_context.Mentor, "MentorId", "MentorId", mentorshipSession.MentorId);
            ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "StudentId", "StudentId", mentorshipSession.StudentId);
            return View(mentorshipSession);
        }

        // POST: MentorshipSessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MentorshipSessionId,Date,Notes,StudentId,MentorId")] MentorshipSession mentorshipSession)
        {
            if (id != mentorshipSession.MentorshipSessionId)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(mentorshipSession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MentorshipSessionExists(mentorshipSession.MentorshipSessionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["MentorId"] = new SelectList(_context.Mentor, "MentorId", "MentorId", mentorshipSession.MentorId);
            ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "StudentId", "StudentId", mentorshipSession.StudentId);
            
        }

        // GET: MentorshipSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentorshipSession = await _context.MentorshipSession
                .Include(m => m.Mentor)
                .Include(m => m.Student)
                .FirstOrDefaultAsync(m => m.MentorshipSessionId == id);
            if (mentorshipSession == null)
            {
                return NotFound();
            }

            return View(mentorshipSession);
        }

        // POST: MentorshipSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mentorshipSession = await _context.MentorshipSession.FindAsync(id);
            if (mentorshipSession != null)
            {
                _context.MentorshipSession.Remove(mentorshipSession);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MentorshipSessionExists(int id)
        {
            return _context.MentorshipSession.Any(e => e.MentorshipSessionId == id);
        }
    }
}
