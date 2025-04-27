using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Models
{
    public class Student
    {
        public int StudentId { get; set; }    // Primary Key
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public int Year { get; set; }

        // Navigation property to link mentorship sessions
        public virtual ICollection<MentorshipSession> MentorshipSessions { get; set; }
    }


}