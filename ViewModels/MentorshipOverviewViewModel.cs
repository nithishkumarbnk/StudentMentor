using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class MentorshipOverviewViewModel
    {
        public List<Mentor> Mentors { get; set; }
        public List<MentorshipSession> MentorshipSessions { get; set; }
        public List<Student> Students { get; set; }
    }

}
