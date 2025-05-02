using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Models
{


    public class MentorshipSession
    {
        public int MentorshipSessionId { get; set; }  // Primary Key
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        // Foreign key for Student
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        // Foreign key for Mentor
        public int MentorId { get; set; }
        public virtual Mentor Mentor { get; set; }
    }


}
