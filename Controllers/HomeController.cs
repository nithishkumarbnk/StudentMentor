using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.ViewModels;
using Microsoft.EntityFrameworkCore; // Add this line



namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebApplication2Context _context;

        public HomeController(WebApplication2Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewMentors()
        {
            var mentors = _context.Mentor.ToList();
            return View("Mentors", mentors);
        }

        public IActionResult ViewStudents()
        {
            var students = _context.Student.ToList();
            return View("Students", students);
        }

        public IActionResult ViewSessions()
        {
            var sessions = _context.MentorshipSession.Include(s => s.Mentor).Include(s => s.Student).ToList();
            return View("MentorshipSessions", sessions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
