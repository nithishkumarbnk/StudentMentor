using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using WebApplication2.Models;

namespace WebApplication2.Models
{
    public class MentorDb : DbContext
    {
        public MentorDb() : base("DefaultConnection") // Make sure this matches your connection string name
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<MentorshipSession> MentorshipSessions { get; set; }
    }
}
