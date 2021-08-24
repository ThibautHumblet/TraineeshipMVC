using System.Collections.Generic;

namespace Axxes.Haxx.Models
{
    public class UpcomingPassedSessionsViewModel
    {
        public IEnumerable<SessionViewModel> UpcomingSessions { get; set; }
        public IEnumerable<SessionViewModel> PassedSessions { get; set; }
    }
}
