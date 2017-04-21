using System;
using System.Collections.Generic;

namespace FootballVideosWebsite.Server.ModelsData
{
    public partial class Teams
    {
        public Teams()
        {
            MatchesAwayTeam = new HashSet<Matches>();
            MatchesHomeTeam = new HashSet<Matches>();
        }

        public int Id { get; set; }
        public int NativeId { get; set; }
        public int WhoScoredId { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }

        public virtual ICollection<Matches> MatchesAwayTeam { get; set; }
        public virtual ICollection<Matches> MatchesHomeTeam { get; set; }
    }
}
