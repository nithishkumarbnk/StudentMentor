using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class WebApplication2Context : DbContext
    {
        public WebApplication2Context(DbContextOptions<WebApplication2Context> options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Mentor> Mentor{ get; set; }
        public DbSet<MentorshipSession> MentorshipSession { get; set; }
    }
}
