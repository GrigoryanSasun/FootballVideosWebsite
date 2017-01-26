using System;
using System.Collections.Generic;

namespace FootBallVideos.ModelsData
{
    public partial class Team
    {
        public Team()
        {
            Players = new HashSet<Players>();
            TeamTournamentMap = new HashSet<TeamTournamentMap>();
        }

        public int Id { get; set; }
        public int? WhoScoredTeamId { get; set; }
        public string TeamName { get; set; }
        public int? TeamAlternativeId { get; set; }
        public string TeamLogoUrl { get; set; }

        public virtual ICollection<Players> Players { get; set; }
        public virtual ICollection<TeamTournamentMap> TeamTournamentMap { get; set; }
        public virtual TeamsAlternative TeamAlternative { get; set; }
    }
}
