using System;
using System.Collections.Generic;

namespace FootBallVideos.ModelsData
{
    public partial class Tournaments
    {
        public Tournaments()
        {
            TeamSeasonTournamentMap = new HashSet<TeamSeasonTournamentMap>();
            Videos = new HashSet<Videos>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string IconPosition { get; set; }
        public int NativeId { get; set; }

        public virtual ICollection<TeamSeasonTournamentMap> TeamSeasonTournamentMap { get; set; }
        public virtual ICollection<Videos> Videos { get; set; }
    }
}
