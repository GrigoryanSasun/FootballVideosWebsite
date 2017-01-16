using System;
using System.Collections.Generic;

namespace FootballAnalyticsAPI.ModelsData
{
    public partial class Season
    {
        public int Id { get; set; }
        public int WhoScoredSeasonId { get; set; }
        public string SeasonTitle { get; set; }
        public int TournamentsId { get; set; }

        public virtual Tournaments Tournaments { get; set; }
    }
}
