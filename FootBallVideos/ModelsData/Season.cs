using System;
using System.Collections.Generic;

namespace FootBallVideos.ModelsData
{
    public partial class Season
    {
        public Season()
        {
            TeamTournamentMap = new HashSet<TeamTournamentMap>();
        }

        public int Id { get; set; }
        public int WhoScoredSeasonId { get; set; }
        public string SeasonTitle { get; set; }
        public int TournamentsId { get; set; }
        public int? StartSeason { get; set; }
        public int? EndSeason { get; set; }

        public virtual ICollection<TeamTournamentMap> TeamTournamentMap { get; set; }
        public virtual Tournaments Tournaments { get; set; }
    }
}
