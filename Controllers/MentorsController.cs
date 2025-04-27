using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MentorsController : Controller
    {
        private readonly WebApplication2Context _context;

        public MentorsController(WebApplication2Context context)
        {
            _context = context;
        }

        // GET: Mentors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mentor.ToListAsync());
        }

        // GET: Mentors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentor = await _context.Mentor
                .FirstOrDefaultAsync(m => m.MentorId == id);
            if (mentor == null)
            {
                return NotFound();
            }

            return View(mentor);
        }

        // GET: Mentors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mentors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MentorId,Name,Email,Expertise")] Mentor mentor)
        {
            _context.Add(mentor);
            await _context.SaveChangesAsync();
            // Redirect to Index after a successful save to confirm data is saved.
            return RedirectToAction(nameof(Index));
        }
        // GET: Mentors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentor = await _context.Mentor.FindAsync(id);
            if (mentor == null)
            {
                return NotFound();
            }
            return View(mentor);
        }

        // POST: Mentors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MentorId,Name,Email,Expertise")] Mentor mentor)
        {
            if (id != mentor.MentorId)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(mentor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MentorExists(mentor.MentorId))
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

        // GET: Mentors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentor = await _context.Mentor
                .FirstOrDefaultAsync(m => m.MentorId == id);
            if (mentor == null)
            {
                return NotFound();
            }

            return View(mentor);
        }

        // POST: Mentors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mentor = await _context.Mentor.FindAsync(id);
            if (mentor != null)
            {
                _context.Mentor.Remove(mentor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MentorExists(int id)
        {
            return _context.Mentor.Any(e => e.MentorId == id);
        }
    }
}
