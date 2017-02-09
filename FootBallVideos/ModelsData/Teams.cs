using System;
using System.Collections.Generic;

namespace FootBallVideos.ModelsData
{
    public partial class Teams
    {
        public Teams()
        {
            MatchesAwayTeam = new HashSet<Matches>();
            MatchesHomeTeam = new HashSet<Matches>();
            Players = new HashSet<Players>();
            TeamSeasonTournamentMap = new HashSet<TeamSeasonTournamentMap>();
            Videos = new HashSet<Videos>();
        }

        public int Id { get; set; }
        public int NativeId { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }

        public virtual ICollection<Matches> MatchesAwayTeam { get; set; }
        public virtual ICollection<Matches> MatchesHomeTeam { get; set; }
        public virtual ICollection<Players> Players { get; set; }
        public virtual ICollection<TeamSeasonTournamentMap> TeamSeasonTournamentMap { get; set; }
        public virtual ICollection<Videos> Videos { get; set; }
    }
}
