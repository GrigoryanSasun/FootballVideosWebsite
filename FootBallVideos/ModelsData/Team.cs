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
        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }
        public string IconColor { get; set; }
        public string ButtonColor { get; set; }
        public string BorderColor { get; set; }
        public string WrapperColor { get; set; }
        public string HoverColor { get; set; }
        public string TittleColor { get; set; }

        public virtual ICollection<Players> Players { get; set; }
        public virtual ICollection<TeamTournamentMap> TeamTournamentMap { get; set; }
        public virtual TeamsAlternative TeamAlternative { get; set; }
    }
}