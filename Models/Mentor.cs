using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{

    public class Mentor
    {
        public int MentorId { get; set; }    // Primary Key
        public string Name { get; set; }
        public string Email { get; set; }
        public string Expertise { get; set; }

        // Navigation property to link mentorship sessions
        public virtual ICollection<MentorshipSession> MentorshipSessions { get; set; }
    }


}