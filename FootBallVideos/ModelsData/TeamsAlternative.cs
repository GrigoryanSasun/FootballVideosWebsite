using System;
using System.Collections.Generic;

namespace FootBallVideos.ModelsData
{
    public partial class TeamsAlternative
    {
        public TeamsAlternative()
        {
            Team = new HashSet<Team>();
        }

        public int Id { get; set; }
        public string TeamAlternativeName { get; set; }
        public int? WhoScoredTeamId { get; set; }
        public DateTime? MatchDate { get; set; }

        public virtual ICollection<Team> Team { get; set; }
    }
}
