using System;
using System.Collections.Generic;

namespace FootballAnalyticsAPI.ModelsData
{
    public partial class Team
    {
        public Team()
        {
            MatchAwayTeam = new HashSet<Match>();
            MatchHomeTeam = new HashSet<Match>();
        }

        public int Id { get; set; }
        public int WhoScoredTeamId { get; set; }
        public string TeamName { get; set; }

        public virtual ICollection<Match> MatchAwayTeam { get; set; }
        public virtual ICollection<Match> MatchHomeTeam { get; set; }
    }
}
