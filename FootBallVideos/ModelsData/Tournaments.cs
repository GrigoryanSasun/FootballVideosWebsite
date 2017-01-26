using System;
using System.Collections.Generic;

namespace FootBallVideos.ModelsData
{
    public partial class Tournaments
    {
        public Tournaments()
        {
            Season = new HashSet<Season>();
            TeamTournamentMap = new HashSet<TeamTournamentMap>();
        }

        public int Id { get; set; }
        public string WhoScoredTourName { get; set; }
        public int WhoScoredTourId { get; set; }

        public virtual ICollection<Season> Season { get; set; }
        public virtual ICollection<TeamTournamentMap> TeamTournamentMap { get; set; }
    }
}
